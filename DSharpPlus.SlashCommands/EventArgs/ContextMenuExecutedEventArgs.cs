using Emzi0767.Utilities;

namespace DSharpPlus.SlashCommands.EventArgs
{
    /// <summary>
    /// Represents arguments for a <see cref="SlashCommandsExtension.ContextMenuErrored"/>
    /// </summary>
    public class ContextMenuExecutedEventArgs : AsyncEventArgs
    {
        /// <summary>
        /// The context of the command.
        /// </summary>
        public virtual ContextMenuContext Context { get; internal set; }
    }
}
