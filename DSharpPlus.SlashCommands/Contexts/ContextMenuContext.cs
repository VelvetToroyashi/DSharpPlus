using DSharpPlus.Entities;

namespace DSharpPlus.SlashCommands
{
    /// <summary>
    /// Respresents a context for a context menu.
    /// </summary>
    public class ContextMenuContext : BaseContext
    {
        /// <summary>
        /// The user this command targets, if applicable.
        /// </summary>
        public virtual DiscordUser TargetUser { get; internal set; }

        /// <summary>
        /// The member this command targets, if applicable.
        /// </summary>
        public DiscordMember TargetMember
            => this.TargetUser is DiscordMember member ? member : null;

        /// <summary>
        /// The message this command targets, if applicable.
        /// </summary>
        public virtual DiscordMessage TargetMessage { get; internal set; }
    }
}
