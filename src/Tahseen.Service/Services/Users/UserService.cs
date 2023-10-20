using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Data.Repositories;
using Tahseen.Domain.Entities;
using Tahseen.Service.DTOs.Feedbacks.UserRatings;
using Tahseen.Service.DTOs.Users.BorrowedBookCart;
using Tahseen.Service.DTOs.Users.Fine;
using Tahseen.Service.DTOs.Users.User;
using Tahseen.Service.DTOs.Users.UserCart;
using Tahseen.Service.DTOs.Users.UserProgressTracking;
using Tahseen.Service.DTOs.Users.UserSettings;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IFeedbackService;
using Tahseen.Service.Interfaces.IUsersService;

namespace Tahseen.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IFineService _fineService;
        private readonly IUserProgressTrackingService _userProgressTrackingService;
        private readonly IUserSettingService _userSettingService;
        private readonly IUserRatingService _userRatingService;
        private readonly IUserCartService _userCartService;
        private readonly IBorrowBookCartService _borrowBookCartService;

        public UserService(IRepository<User> userRepository, IMapper mapper, IFineService fineService,
            IUserProgressTrackingService userProgressTrackingService, IUserSettingService userSettingService,
            IUserRatingService userRatingService, IUserCartService userCartService, IBorrowBookCartService borrowBookCartService)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._fineService = fineService;
            this._userProgressTrackingService = userProgressTrackingService;
            this._userSettingService = userSettingService;
            this._userRatingService = userRatingService;
            this._userCartService = userCartService;
            this._borrowBookCartService = borrowBookCartService;
        }
        public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
        {
            var result = await _userRepository.SelectAll().Where(e => e.EmailAddress == dto.EmailAddress && e.Password == e.Password && e.IsDeleted == false).FirstOrDefaultAsync();
            if (result != null)
            {
                throw new TahseenException(400, "User is exist");
            }
            var data = this._mapper.Map<User>(dto);
            var CreatedData = await this._userRepository.CreateAsync(data);

            var UserSettingCreation = new UserSettingsForCreationDto()
            {
                LanguagePreference = Domain.Enums.LanguagePreference.Uzbek,
                NotificationPreference = Domain.Enums.NotificationStatus.Read,
                ThemePreference = Domain.Enums.ThemePreference.Light,
                UserId = CreatedData.Id,
                

            };

            await this._userSettingService.AddAsync(UserSettingCreation);
            
            var UserRatingForCreation = new UserRatingForCreationDto()
            {
                BooksCompleted = 0,
                Rating = 0,
                UserId = CreatedData.Id,
            };

            await _userRatingService.AddAsync(UserRatingForCreation);


            var UserCartCreation = new UserCartForCreationDto()
            {
                UserId = CreatedData.Id,
                

            };
            await this._userCartService.AddAsync(UserCartCreation);

            var borrowBookCartCreationDto = new BorrowedBookCartForCreationDto { UserId = CreatedData.Id };
            await _borrowBookCartService.AddAsync(borrowBookCartCreationDto);

            return _mapper.Map<UserForResultDto>(CreatedData);

        }

        public async Task<UserForResultDto> ModifyAsync(long Id, UserForUpdateDto dto)
        {
            var data = await _userRepository.SelectAll().Where(e => e.Id == Id && e.IsDeleted == false).FirstOrDefaultAsync();
            if (data is not null)
            {
                var MappedData = this._mapper.Map(dto, data);
                MappedData.UpdatedAt = DateTime.UtcNow;
                var result = await _userRepository.CreateAsync(MappedData);
                return _mapper.Map<UserForResultDto>(result);
            }
            throw new TahseenException(404, "User is not found");
        }

        public async Task<bool> RemoveAsync(long Id)
        {
            return await _userRepository.DeleteAsync(Id);
        }

        public async Task<IQueryable<UserForResultDto>> RetrieveAllAsync()
        {
            var AllData = _userRepository.SelectAll().Where(t => t.IsDeleted == false);
            return _mapper.Map<IQueryable<UserForResultDto>>(AllData);
        }

        public async Task<UserForResultDto> RetrieveByIdAsync(long Id)
        {
            var data = await _userRepository.SelectByIdAsync(Id);
            if(data != null && data.IsDeleted == false)
            {
                return this._mapper.Map<UserForResultDto>(data);
            }
            throw new TahseenException(404, "User is not found");
        }
    }
}
