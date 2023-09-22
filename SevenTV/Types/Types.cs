namespace SevenTV.Types
{
    public enum ConnectionType { TWITCH, YOUTUBE, DISCORD, KICK };
    public class Connection
    {
        public string? id = null;
        public string? platform = null;
        public string? username = null;
        public string? display_name = null;
        public long linked_at = 0;
        public int emote_capacity = 0;
        public EmoteSet? emote_set = null;
        public User? user = null;
    }
    public class User
    {
        public string? id = null;
        public string? username = null;
        public string? display_name = null;
        public long createdAt = 0;
        public string? avatar_url = null;
        public string? biography = null;
        public Style? style = null;
        public EmoteSet[]? emote_sets = null;
        public Editor[]? editors = null;
        public string[]? roles = null;
        public Connection[]? connections = null;
    }
    public class Style
    {
        public int color = 0;
        public string? paint = null;
    }
    public class Editor
    {
        public string? id = null;
        public int permissions = 0;
        public bool visible = false;
        public long added_at = 0;
    }
    public class EmoteSet
    {
        public string? id = null;
        public string? name = null;
        public string[]? tags = null;
        public bool immutable = false;
        public bool privileged = false;
        public Emote[]? emotes = null;
        public int capacity = 0;
        public User? owner = null;
    }
    public class Emote
    {
        public string? id = null;
        public string? name = null;
        public int flags = 0;
        public long timestamp = 0;
        public string? actor_id = null;
        public EmoteData? data = null;
    }
    public class EmoteData
    {
        public string? id = null;
        public string? name = null;
        public int flags = 0;
        public int lifecycle = 0;
        public bool listed = false;
        public bool animated = false;
        public User? owner = null;
        public EmoteHost? host = null;
    }
    public class EmoteHost
    {
        public string? url = null;
        public EmoteFile[]? files = null;
    }
    public class EmoteFile
    {
        public string? name = null;
        public string? static_name = null;
        public int width = 0;
        public int height = 0;
        public long size = 0;
        public string? format = null;
    }
    public class TwitchUser
    {
        public bool banned = false;
        public string? banReason = null;
        public string? displayName = null;
        public string? login = null;
        public string? id = null;
        public string? bio = null;
        public int? follows = 0;
        public int? followers = 0;
        public int? panelCount = 0;
        public string? chatColor = null;
        public string? logo = null;
        public string? banner = null;
        public string? verifiedBot = null;
        public string? createdAt = null;
        public string? updatedAt = null;
        public string? emotePrefix = null;
        public TwitchRoles roles = new TwitchRoles();
        public TwitchBadge[]? badges = null;
        public int? chatterCount = null;
        public TwitchChatSettings chatSettings = new TwitchChatSettings();
        public TwitchStream? stream = null;
        public TwitchLastStream? lastBroadcast = null;
        public TwitchPanel[] panels = new TwitchPanel[0];
    }
    public class TwitchRoles
    {
        public bool isAffiliate = false;
        public bool isPartner = false;
        public bool? isStaff = null;
    }
    public class TwitchBadge
    {
        public string? setID = null;
        public string? title = null;
        public string? description = null;
        public string? version = null;
    }
    public class TwitchChatSettings
    {
        public int? chatDelayMs = null;
        public int? followersOnlyDurationMinutes = null;
        public int? slowModeDurationSeconds = null;
        public bool blockLinks = false;
        public bool isSubscribersOnlyModeEnabled = false;
        public bool isEmoteOnlyModeEnabled = false;
        public bool isFastSubsModeEnabled = false;
        public bool isUniqueChatModeEnabled = false;
        public bool requireVerifiedAccount = false;
        public string[] rules = new string[0];
    }
    public class TwitchStream
    {
        public string? title = null;
        public string id = string.Empty;
        public string createdAt = string.Empty;
        public string type = string.Empty;
        public int viewersCount = 0;
        public TwitchGame game = new TwitchGame();
    }
    public class TwitchGame
    {
        public string displayName = string.Empty;
    }
    public class TwitchLastStream
    {
        public string? startedAt = null;
        public string? title = null;
    }
    public class TwitchPanel
    {
        public string id = string.Empty;
    }
}