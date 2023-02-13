using System.Threading.Tasks;
using chessAPI.models.player;

namespace chessAPI.business.interfaces;

public interface IPlayerBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsPlayer<TI>> addPlayer(clsNewPlayer newPlayer);
    Task<clsPlayer<TI>> updatePlayer(clsPlayer<TI> newPlayer);
    Task<IEnumerable<clsPlayer<TI>>> getPlayers();
}