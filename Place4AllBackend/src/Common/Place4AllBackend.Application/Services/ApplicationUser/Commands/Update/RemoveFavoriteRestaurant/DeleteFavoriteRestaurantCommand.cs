using Place4AllBackend.Application.Common.Interfaces;
using Place4AllBackend.Application.Dto;

namespace Place4AllBackend.Application.ApplicationUser.Commands.Update.RemoveFavoriteRestaurant
{
    public class DeleteFavoriteRestaurantCommand : IRequestWrapper<ApplicationUserDto>
    {
        public int FavoriteRestaurantId { get; set; }
    }
}
