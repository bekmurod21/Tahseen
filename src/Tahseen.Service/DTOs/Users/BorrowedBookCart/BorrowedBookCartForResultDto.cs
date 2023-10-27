﻿using Tahseen.Service.DTOs.Users.BorrowedBook;

namespace Tahseen.Service.DTOs.Users.BorrowedBookCart
{
    public class BorrowedBookCartForResultDto
    {
        public long UserId { get; set; }
        public long BorrowedBookCartId { get; set; }
        public IEnumerable<BorrowedBookForResultDto> BorrowedBook { get; set; }
    }
}
