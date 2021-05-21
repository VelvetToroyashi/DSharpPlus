// This file is part of the DSharpPlus project.
//
// Copyright (c) 2015 Mike Santiago
// Copyright (c) 2016-2021 DSharpPlus Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DSharpPlus.Entities
{
    /// <summary>
    /// Constructs an interaction response.
    /// </summary>
    public sealed class DiscordInteractionResponseBuilder
    {
        /// <summary>
        /// Whether this interaction response is text-to-speech.
        /// </summary>
        public bool IsTTS { get; set; }

        /// <summary>
        /// Whether this interaction response should be ephemeral.
        /// </summary>
        public bool IsEphemeral { get; set; }

        /// <summary>
        /// Content of the message to send.
        /// </summary>
        public string Content
        {
            get => this._content;
            set
            {
                if (value != null && value.Length > 2000)
                    throw new ArgumentException("Content length cannot exceed 2000 characters.", nameof(value));
                this._content = value;
            }
        }
        private string _content;

        /// <summary>
        /// Embeds to send on this interaction response.
        /// </summary>
        public IReadOnlyList<DiscordEmbed> Embeds => this._embeds;
        private readonly List<DiscordEmbed> _embeds = new();

        public IReadOnlyList<DiscordActionRowComponent> Components => this._components;
        private readonly List<DiscordActionRowComponent> _components = new();


        /// <summary>
        /// Mentions to send on this interaction response.
        /// </summary>
        public IEnumerable<IMention> Mentions { get; }
        private readonly List<IMention> _mentions = new();

        /// <summary>
        /// Constructs a new empty interaction response builder.
        /// </summary>
        public DiscordInteractionResponseBuilder()
        {
            // Why were you initializing collections with empty collections? //
            //this.Embeds = new ReadOnlyCollection<DiscordEmbed>(this._embeds);
            //this.Mentions = new ReadOnlyCollection<IMention>(this._mentions);
        }

        public DiscordInteractionResponseBuilder(DiscordMessageBuilder builder)
        {
            this._components = builder.Components;
            this._content = builder.Content;
            this._mentions = builder.Mentions;
            this._embeds.Add(builder.Embed);
        }

        public DiscordInteractionResponseBuilder WithComponents(IEnumerable<DiscordComponent> components)
        {
            var count = components.Count();

            if (count > 5)
                throw new ArgumentException("Cannot add more than 5 components per action row!");

            var arc = new DiscordActionRowComponent(components);
            this._components.Add(arc);
            return this;
        }

        /// <summary>
        /// Indicates if the interaction response will be text-to-speech.
        /// </summary>
        /// <param name="tts">Text-to-speech</param>
        public DiscordInteractionResponseBuilder WithTTS(bool tts)
        {
            this.IsTTS = tts;
            return this;
        }

        /// <summary>
        /// Sets the interaction response to be ephemeral.
        /// </summary>
        /// <param name="ephemeral">Ephemeral.</param>
        public DiscordInteractionResponseBuilder AsEphemeral(bool ephemeral)
        {
            this.IsEphemeral = ephemeral;
            return this;
        }

        /// <summary>
        /// Sets the content of the message to send.
        /// </summary>
        /// <param name="content">Content to send.</param>
        public DiscordInteractionResponseBuilder WithContent(string content)
        {
            this.Content = content;
            return this;
        }

        /// <summary>
        /// Adds an embed to send with the interaction response.
        /// </summary>
        /// <param name="embed">Embed to add.</param>
        public DiscordInteractionResponseBuilder AddEmbed(DiscordEmbed embed)
        {
            this._embeds.Add(embed);
            return this;
        }

        /// <summary>
        /// Adds the given embeds to send with the interaction response.
        /// </summary>
        /// <param name="embeds">Embeds to add.</param>
        public DiscordInteractionResponseBuilder AddEmbeds(IEnumerable<DiscordEmbed> embeds)
        {
            this._embeds.AddRange(embeds);
            return this;
        }

        /// <summary>
        /// Adds the mention to the mentions to parse, etc. with the interaction response.
        /// </summary>
        /// <param name="mention">Mention to add.</param>
        public DiscordInteractionResponseBuilder AddMention(IMention mention)
        {
            this._mentions.Add(mention);
            return this;
        }

        /// <summary>
        /// Adds the mentions to the mentions to parse, etc. with the interaction response.
        /// </summary>
        /// <param name="mentions">Mentions to add.</param>
        public DiscordInteractionResponseBuilder AddMentions(IEnumerable<IMention> mentions)
        {
            this._mentions.AddRange(mentions);
            return this;
        }

        /// <summary>
        /// Allows for clearing the Interaction Response Builder so that it can be used again to send a new response.
        /// </summary>
        public void Clear()
        {
            this.Content = "";
            this._embeds.Clear();
            this.IsTTS = false;
            this.IsEphemeral = false;
            this._mentions.Clear();
            this._components.Clear();
        }
    }
}
