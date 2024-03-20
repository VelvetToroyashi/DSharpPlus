using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSharpPlus.Entities;

/// <summary>
/// Represents metadata for an interaction.
/// </summary>
public abstract class DiscordInteractionMetadata : SnowflakeObject
{
    /// <summary>
    /// Gets the name of the command, if applicable.
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; internal set; }

    /// <summary>
    /// Gets the type of the interaction.
    /// </summary>
    [JsonProperty("type")]
    public InteractionType Type { get; internal set; }

    /// <summary>
    /// Gets the user that invoked this interaction.
    /// </summary>
    [JsonIgnore]
    public DiscordUser User => this.Discord.GetCachedOrEmptyUserInternal(this.UserId);
    
    [JsonProperty("user_id")]
    internal ulong UserId { get; set; }
    
    /// <summary>
    /// Gets integration owners responsible for authorizing this interaction.
    /// </summary>
    /// <remarks>
    /// If this command was invoked in a guild, a key of a guild and the guild's ID will be present, otherwise the value will be zero. The user's ID is always present.
    /// </remarks>
    [JsonIgnore]
    public IReadOnlyDictionary<ApplicationIntegrationType, ulong> AuthorizingIntegrationOwners => this._authorizingIntegrationOwners;
    
    [JsonProperty("authorizing_integration_owners", NullValueHandling = NullValueHandling.Ignore)]
    private Dictionary<ApplicationIntegrationType, ulong> _authorizingIntegrationOwners;
    
    /// <summary>
    /// Gets the ID of the message that was responded to, if this interaction was a followup response.
    /// </summary>
    [JsonProperty("original_response_message_id", NullValueHandling = NullValueHandling.Ignore)]
    public ulong? OriginalMessageID { get; internal set; }
    
    internal DiscordInteractionMetadata() { }
}
