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
using DSharpPlus.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DSharpPlus.Net.Abstractions
{
    internal class AuditLogUser
    {
        [JsonProperty("username")]
        public virtual string Username { get; set; }

        [JsonProperty("discriminator")]
        public virtual string Discriminator { get; set; }

        [JsonProperty("id")]
        public virtual ulong Id { get; set; }

        [JsonProperty("avatar")]
        public virtual string AvatarHash { get; set; }
    }

    internal class AuditLogWebhook
    {
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("channel_id")]
        public virtual ulong ChannelId { get; set; }

        [JsonProperty("token")]
        public virtual string Token { get; set; }

        [JsonProperty("avatar")]
        public virtual string AvatarHash { get; set; }

        [JsonProperty("guild_id")]
        public virtual ulong GuildId { get; set; }

        [JsonProperty("id")]
        public virtual ulong Id { get; set; }
    }

    internal class AuditLogActionChange
    {
        // this can be a string or an array
        [JsonProperty("old_value")]
        public virtual object OldValue { get; set; }

        [JsonIgnore]
        public IEnumerable<JObject> OldValues
            => (this.OldValue as JArray)?.ToObject<IEnumerable<JObject>>();

        [JsonIgnore]
        public ulong OldValueUlong
            => (ulong)this.OldValue;

        [JsonIgnore]
        public string OldValueString
            => (string)this.OldValue;

        // this can be a string or an array
        [JsonProperty("new_value")]
        public virtual object NewValue { get; set; }

        [JsonIgnore]
        public IEnumerable<JObject> NewValues
            => (this.NewValue as JArray)?.ToObject<IEnumerable<JObject>>();

        [JsonIgnore]
        public ulong NewValueUlong
            => (ulong)this.NewValue;

        [JsonIgnore]
        public string NewValueString
            => (string)this.NewValue;

        [JsonProperty("key")]
        public virtual string Key { get; set; }
    }

    internal class AuditLogActionOptions
    {
        [JsonProperty("type")]
        public virtual object Type { get; set; }

        [JsonProperty("id")]
        public virtual ulong Id { get; set; }

        [JsonProperty("channel_id")]
        public virtual ulong ChannelId { get; set; }

        [JsonProperty("message_id")]
        public virtual ulong MessageId { get; set; }

        [JsonProperty("count")]
        public virtual int Count { get; set; }

        [JsonProperty("delete_member_days")]
        public virtual int DeleteMemberDays { get; set; }

        [JsonProperty("members_removed")]
        public virtual int MembersRemoved { get; set; }
    }

    internal class AuditLogAction
    {
        [JsonProperty("target_id")]
        public ulong? TargetId { get; set; }

        [JsonProperty("user_id")]
        public virtual ulong UserId { get; set; }

        [JsonProperty("id")]
        public virtual ulong Id { get; set; }

        [JsonProperty("action_type")]
        public virtual AuditLogActionType ActionType { get; set; }

        [JsonProperty("changes")]
        public IEnumerable<AuditLogActionChange> Changes { get; set; }

        [JsonProperty("options")]
        public virtual AuditLogActionOptions Options { get; set; }

        [JsonProperty("reason")]
        public virtual string Reason { get; set; }
    }

    internal class AuditLog
    {
        [JsonProperty("webhooks")]
        public IEnumerable<AuditLogWebhook> Webhooks { get; set; }

        [JsonProperty("users")]
        public IEnumerable<AuditLogUser> Users { get; set; }

        [JsonProperty("audit_log_entries")]
        public IEnumerable<AuditLogAction> Entries { get; set; }
    }
}
