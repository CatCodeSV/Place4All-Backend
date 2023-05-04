using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Update.AddFavoriteRestaurant
{
    public class AddFavoriteRestaurantCommand : IRequestWrapper<ApplicationUserDto>
    {
        public int FavoriteRestaurantId { get; set; }
    }

}
