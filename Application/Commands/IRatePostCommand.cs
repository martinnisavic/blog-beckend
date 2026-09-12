using Application.DTO.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IRatePostCommand : ICommand<RatePostDTO>
    {
    }
}
