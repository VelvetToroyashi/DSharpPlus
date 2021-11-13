using Emzi0767.Utilities;
using System;

namespace DSharpPlus.SlashCommands.EventArgs
{
    /// <summary>
    /// Represents arguments for a <see cref="SlashCommandsExtension.SlashCommandErrored"/> event.
    /// </summary>
    public class SlashCommandErrorEventArgs : AsyncEventArgs
    {
        /// <summary>
        /// The context of the command.
        /// </summary>
        public virtual InteractionContext Context { get; internal set; }

        /// <summary>
        /// The exception thrown.
        /// </summary>
        public virtual Exception Exception { get; internal set; }
    }
}
