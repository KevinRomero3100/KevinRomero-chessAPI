using System.Linq;
using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.player;

namespace chessAPI.business.impl;

public sealed class clsPlayerBusiness<TI, TC> : IPlayerBusiness<TI>
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly IPlayerRepository<TI, TC> playerRepository;

    public clsPlayerBusiness(IPlayerRepository<TI, TC> playerRepository)
    {
        this.playerRepository = playerRepository;
    }

    public async Task<clsPlayer<TI>> addPlayer(clsNewPlayer newPlayer)
    {
        var x = await playerRepository.addPlayer(newPlayer).ConfigureAwait(false);
        return new clsPlayer<TI>(x, newPlayer.email);
    }

    public async Task<IEnumerable<clsPlayer<TI>>> getPlayers()
    {
        var x = await playerRepository.getPlayers().ConfigureAwait(false);
        return x.ToList().Select(y => (clsPlayer<TI>)y);
    }

    public async Task<clsPlayer<TI>> updatePlayer(clsPlayer<TI> newPlayer)
    {
        var x = await playerRepository.updatePlayer(newPlayer).ConfigureAwait(false);
        return new clsPlayer<TI>(x, newPlayer.email);

    }
}