using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SevenTV.Types.GraphQL
{
    public class Response<T> where T : class
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public List<GraphQLError>? Errors { get; set; }
        public string raw { get; set; } = string.Empty;
    }
    public class GraphQLError
    {
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, object>? Extensions { get; set; }
    }
    public class GraphQLRawResponse<T> where T : class
    {
        public T? Data { get; set; }
        public List<GraphQLError>? Errors { get; set; }
    }


    public class UserEditorForResponse
    {
        public UsersWrapper? Users { get; set; }
    }
    public class EmoteSearchResponse
    {
        public EmotesWrapper? Emotes { get; set; }
    }
    public class AddEmoteResponse
    {
        public EmoteSetsAddWrapper? EmoteSets { get; set; }
    }
    public class RemoveEmoteResponse
    {
        public EmoteSetsRemoveWrapper? EmoteSets { get; set; }
    }
    public class RenameEmoteInSetResponse
    {
        public EmoteSetsAliasWrapper? EmoteSets { get; set; }
    }
    public class AddEditorResponse
    {
        public UserEditorsWrapper? UserEditors { get; set; }
    }
    public class DeleteEditorResponse
    {
        public UserEditorWrapper? UserEditors { get; set; }
    }
    public class UpdateEditorPermissionsResponse
    {
        public UpdateUserEditorsWrapper? UserEditors { get; set; }
    }
    public class CreateEmoteSetResponse
    {
        public EmoteSetsCreateWrapper? EmoteSets { get; set; }
    }
    public class DeleteSetResponse
    {
        public EmoteSetsDeleteWrapper? EmoteSets { get; set; }
    }
    public class UpdateEmoteSetNameResponse
    {
        public EmoteSetsRenameWrapper? EmoteSets { get; set; }
    }
    public class UpdateEmoteSetCapacityResponse
    {
        public EmoteSetsCapacityWrapper? EmoteSets { get; set; }
    }
    public class UpdateEmoteSetTagsResponse
    {
        public EmoteSetsTagsWrapper? EmoteSets { get; set; }
    }
    public class SetActiveBadgeResponse
    {
        public UsersBadgeWrapper? Users { get; set; }
    }
    public class SetActivePaintResponse
    {
        public UsersPaintWrapper? Users { get; set; }
    }
    public class UserEditorsResponse
    {
        public UsersEditorsWrapper? Users { get; set; }
    }

    public class UsersWrapper
    {
        public User? User { get; set; }
    }

    public class User
    {
        public string Id { get; set; } = string.Empty;
        public MainConnection? MainConnection { get; set; }
        public List<EditorFor>? EditorFor { get; set; }
    }

    public class MainConnection
    {
        public string PlatformDisplayName { get; set; } = string.Empty;
        public string PlatformAvatarUrl { get; set; } = string.Empty;
    }

    public class EditorFor
    {
        public string UserId { get; set; } = string.Empty;
        public string EditorId { get; set; } = string.Empty;
        public User? User { get; set; }
        public string State { get; set; } = string.Empty;
        public Permissions? Permissions { get; set; }
        public string UpdatedAt { get; set; } = string.Empty;
    }

    public class Permissions
    {
        public EmoteSetPermission? EmoteSet { get; set; }
        public EmotePermission? Emote { get; set; }
        public UserPermission? User { get; set; }
        public bool SuperAdmin { get; set; }
    }

    public class EmoteSetPermission
    {
        public bool Manage { get; set; }
        public bool Admin { get; set; }
        public bool Create { get; set; }
    }

    public class EmotePermission
    {
        public bool Manage { get; set; }
        public bool Admin { get; set; }
        public bool Create { get; set; }
        public bool Transfer { get; set; }
    }

    public class UserPermission
    {
        public bool ManageProfile { get; set; }
        public bool ManageEditors { get; set; }
        public bool ManagePersonalEmoteSet { get; set; }
        public bool ManageBilling { get; set; }
        public bool Admin { get; set; }
    }

    public class EmotesWrapper
    {
        public Search? Search { get; set; }
    }

    public class Search
    {
        public SearchItem[]? Items { get; set; }
    }

    public class SearchItem
    {
        public string Id { get; set; } = string.Empty;
        public string DefaultName { get; set; } = string.Empty;
        public Owner? Owner { get; set; }
        public bool Deleted { get; set; }
        public Flags? Flags { get; set; }
        public bool ImagesPending { get; set; }
        public Image[]? Images { get; set; }
        public int? Ranking { get; set; }
    }

    public class Owner
    {
        public string? Id { get; set; }
        public MainConnection? MainConnection { get; set; }
        public JObject? Style { get; set; }
        public RoleColor? HighestRoleColor { get; set; }
    }

    public class Flags
    {
        public bool DefaultZeroWidth { get; set; }
        public bool Private { get; set; }
        public bool PublicListed { get; set; }
    }

    public class Image
    {
        public Uri? Url { get; set; }
        public string Mime { get; set; } = string.Empty;
        public long size { get; set; }
        public long scale { get; set; }
        public long width { get; set; }
        public long frameCount { get; set; }
    }

    public class RoleColor
    {
        public string Hex { get; set; } = string.Empty;
    }

    public class EmoteSetsAddWrapper
    {
        public EmoteSetAdd? EmoteSet { get; set; }
    }

    public class EmoteSetAdd
    {
        public EmoteOperation? AddEmote { get; set; }
    }

    public class EmoteOperation
    {
        public string Id { get; set; } = string.Empty;
        public Emotes? Emotes { get; set; }
    }

    public class Emotes
    {
        public EmoteItem[]? Items { get; set; }
    }

    public class EmoteItem
    {
        public string Id { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public Emote? Emote { get; set; }
    }

    public class Emote
    {
        public string Id { get; set; } = string.Empty;
        public string DefaultName { get; set; } = string.Empty;
        public string[] Tags { get; set; } = new string[0];
    }

    public class EmoteSetsRemoveWrapper
    {
        public EmoteSetRemove? EmoteSet { get; set; }
    }

    public class EmoteSetRemove
    {
        public EmoteOperation? RemoveEmote { get; set; }
    }

    public class EmoteSetsAliasWrapper
    {
        public EmoteSetAlias? EmoteSet { get; set; }
    }

    public class EmoteSetAlias
    {
        public EmoteAliasOperation? UpdateEmoteAlias { get; set; }
    }

    public class EmoteAliasOperation
    {
        public string Id { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public Emote? Emote { get; set; }
    }

    public class UserEditorsWrapper
    {
        public EditorCreate? Create { get; set; }
    }
    public class UserEditorWrapper
    {
        public EditorWrapper? Editor { get; set; }
    }

    public class EditorCreate
    {
        public string UserId { get; set; } = string.Empty;
        public string EditorId { get; set; } = string.Empty;
        public Editor? Editor { get; set; }
        public string State { get; set; } = string.Empty;
        public Permissions? Permissions { get; set; }
        public DateTime? updatedAt { get; set; }
    }

    public class Editor
    {
        public string Id { get; set; } = string.Empty;
        public MainConnection? MainConnection { get; set; }
        public Style? Style { get; set; }
        public RoleColor? HighestRoleColor { get; set; }
    }

    public class EditorWrapper
    {
        public bool delete { get; set; }
    }

    public class UpdateUserEditorsWrapper
    {
        public EditorUpdateWrapper? Editor { get; set; }
    }

    public class EditorUpdateWrapper
    {
        public EditorCreate? UpdatePermissions { get; set; }
    }

    public class EmoteSetsCreateWrapper
    {
        public EmoteSetCreate? Create { get; set; }
    }

    public class EmoteSetCreate
    {
        public string Id { get; set; } = string.Empty;
    }

    public class EmoteSetsDeleteWrapper
    {
        public EmoteSetDelete? EmoteSet { get; set; }
    }

    public class EmoteSetDelete
    {
        public bool delete { get; set; }
    }

    public class EmoteSetsRenameWrapper
    {
        public EmoteSetRename? EmoteSet { get; set; }
    }

    public class EmoteSetRename
    {
        public EmoteSet? Name { get; set; }
    }

    public class EmoteSet
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; } = 0;
        public string Kind { get; set; } = string.Empty;
        public string[] Tags { get; set; } = new string[0];
        public Owner? Owner { get; set; }
    }

    public class EmoteSetsCapacityWrapper
    {
        public EmoteSetCapacity? EmoteSet { get; set; }
    }

    public class EmoteSetCapacity
    {
        public EmoteSet? Capacity { get; set; }
    }

    public class EmoteSetsTagsWrapper
    {
        public EmoteSetTags? EmoteSet { get; set; }
    }

    public class EmoteSetTags
    {
        public EmoteSet? Tags { get; set; }
    }

    public class UsersBadgeWrapper
    {
        public UserBadge? User { get; set; }
    }

    public class UserBadge
    {
        public UserActiveBadge? ActiveBadge { get; set; }
    }

    public class UserActiveBadge
    {
        public string Id { get; set; } = string.Empty;
        public Style? Style { get; set; }
    }

    public class Style
    {
        public ActiveCosmetic? ActiveBadge { get; set; }
        public ActiveCosmetic? ActivePaint { get; set; }
    }

    public class ActiveCosmetic
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class UsersPaintWrapper
    {
        public UserPaint? User { get; set; }
    }

    public class UserPaint
    {
        public UserActivePaint? ActivePaint { get; set; }
    }

    public class UserActivePaint
    {
        public string Id { get; set; } = string.Empty;
        public Style? Style { get; set; }
    }

    public class UsersEditorsWrapper
    {
        public UserEditors? User { get; set; }
    }

    public class UserEditors
    {
        public Editors[]? Editors { get; set; }
    }

    public class Editors
    {
        public string UserId { get; set; } = string.Empty;
        public string EditorId { get; set; } = string.Empty;
        public Editor? Editor { get; set; }
        public string State { get; set; } = string.Empty;
        public Permissions? Permissions { get; set; }
        public DateTime? updatedAt { get; set; }
    }
}