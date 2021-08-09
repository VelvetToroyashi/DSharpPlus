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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSharpPlus.Entities
{
    /// <summary>
    /// Represents options for <see cref="DiscordSelectComponent"/>.
    /// </summary>
    public sealed class DiscordSelectComponentOption
    {
        /// <summary>
        /// The label to add. This is required.
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; internal set; }

        /// <summary>
        /// The value of this option. Akin to the Custom Id of components.
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; internal set; }

        /// <summary>
        /// Whether this option is default. If true, this option will be pre-selected. Defaults to false.
        /// </summary>
        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool Default { get; internal set; } // false //

        /// <summary>
        /// The description of this option. This is optional.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; internal set; }

        /// <summary>
        /// The emoji of this option. This is optional.
        /// </summary>
        [JsonProperty("emoji", NullValueHandling = NullValueHandling.Ignore)]
        public DiscordComponentEmoji Emoji { get; internal set; }

        public DiscordSelectComponentOption(string label, string value, string description = null, bool isDefault = false, DiscordComponentEmoji emoji = null)
        {
            this.Label = label;
            this.Value = value;
            this.Description = description;
            this.Default = isDefault;
            this.Emoji = emoji;



            // Create the options for the user to pick
            var options = new List<DiscordSelectComponentOption>()
            {
                new DiscordSelectComponentOption("Label, no description", "label_no_desc"),
                new DiscordSelectComponentOption("Label, Description", "label_with_desc", "This is a description!"),
                new DiscordSelectComponentOption("Label, Description, Emoji", "label_with_desc_emoji", "This is a description!", emoji: new DiscordComponentEmoji(854260064906117121)),
                new DiscordSelectComponentOption("Label, Description, Emoji (Default selection)", "label_with_desc_emoji_default", "This is a description!", isDefault: true, new DiscordComponentEmoji(854260064906117121))
            };

// Make the dropdown
            var dropdown = new DiscordSelectComponent("dropdown", null, options, false, 1, 2);

// [...] Code trunctated for brevity

            var builder = new DiscordMessageBuilder().WithContent("Look, it's a dropdown!").AddComponents(dropdown);

        }
    }
}
