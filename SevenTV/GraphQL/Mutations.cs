namespace SevenTV.GraphQL
{
    public static class Mutations
    {
        // EMOTES
        public static string AddEmote = @"
mutation AddEmoteToSet($setId: Id!, $emote: EmoteSetEmoteId!) {
  emoteSets {
    emoteSet(id: $setId) {
      addEmote(id: $emote) {
        id
        emotes {
            items {
                id
                alias
                emote {
                    id
                    defaultName
                    tags
                }
            }
        }
        __typename
      }
      __typename
    }
    __typename
  }
}";

        public static string RemoveEmote = @"
mutation RemoveEmoteFromSet($setId: Id!, $emote: EmoteSetEmoteId!) {
  emoteSets {
    emoteSet(id: $setId) {
      removeEmote(id: $emote) {
        id
        emotes {
            items {
                id
                alias
                emote {
                    id
                    defaultName
                    tags
                }
            }
        }
        __typename
      }
      __typename
    }
    __typename
  }
}";

        public static string AliasEmote = @"
mutation RenameEmoteInSet($setId: Id!, $emote: EmoteSetEmoteId!, $alias: String!) {
  emoteSets {
    emoteSet(id: $setId) {
      updateEmoteAlias(id: $emote, alias: $alias) {
        id
        alias
        emote {
            id
            defaultName
            tags
        }
        __typename
      }
      __typename
    }
    __typename
  }
}";

        // EDITORS
        public static string AddEditor = @"
mutation AddEditor($userId: Id!, $editorId: Id!, $permissions: UserEditorPermissionsInput!) {
  userEditors {
    create(userId: $userId, editorId: $editorId, permissions: $permissions) {
      userId
      editorId
      editor {
        id
        __typename
      }
      state
      permissions {
        superAdmin
        emoteSet {
          admin
          create
          manage
          __typename
        }
        emote {
          admin
          create
          manage
          transfer
          __typename
        }
        user {
          admin
          manageBilling
          manageEditors
          managePersonalEmoteSet
          manageProfile
          __typename
        }
        __typename
      }
      updatedAt
      __typename
    }
    __typename
  }
}";
        public static string RemoveEditor = @"
mutation DeleteEditor($userId: Id!, $editorId: Id!) {
  userEditors {
    editor(userId: $userId, editorId: $editorId) {
      delete
      __typename
    }
    __typename
  }
}";
        public static string UpdateEditor = @"
mutation UpdateEditorPermissions($userId: Id!, $editorId: Id!, $permissions: UserEditorPermissionsInput!) {
  userEditors {
    editor(userId: $userId, editorId: $editorId) {
      updatePermissions(permissions: $permissions) {
        userId
        editorId
        state
        updatedAt
        editor {
          id
          }
        permissions {
          superAdmin
          emoteSet {
            admin
            create
            manage
            __typename
          }
          emote {
            admin
            create
            manage
            transfer
            __typename
          }
          user {
            admin
            manageBilling
            manageEditors
            managePersonalEmoteSet
            manageProfile
            __typename
          }
          __typename
        }
        __typename
      }
      __typename
    }
    __typename
  }
}";

        //EmoteSets
        public static string CreateEmoteSet = @"
mutation CreateEmoteSet($name: String!, $tags: [String!]!, $ownerId: Id!) {
  emoteSets {
    create(name: $name, tags: $tags, ownerId: $ownerId) {
      id
      __typename
    }
    __typename
  }
}";
        public static string DeleteEmoteSet = @"
mutation DeleteSet($id: Id!) {
  emoteSets {
    emoteSet(id: $id) {
      delete
      __typename
    }
    __typename
  }
}";
        public static string UpdateEmoteSetName = @"
mutation UpdateEmoteSetName($id: Id!, $name: String!) {
  emoteSets {
    emoteSet(id: $id) {
      name(name: $name) {
        id
        name
        capacity
        kind
        tags
        owner {
          id
          __typename
        }
        __typename
      }
      __typename
    }
    __typename
  }
}";
        public static string UpdateEmoteSetCapacity = @"
mutation UpdateEmoteSetCapacity($id: Id!, $capacity: Int!) {
  emoteSets {
    emoteSet(id: $id) {
      capacity(capacity: $capacity) {
        id
        name
        capacity
        kind
        tags
        owner {
          id
          __typename
        }
        __typename
      }
      __typename
    }
    __typename
  }
}";
        public static string UpdateEmoteSetTags = @"
mutation UpdateEmoteSetTags($id: Id!, $tags: [String!]!) {
  emoteSets {
    emoteSet(id: $id) {
      tags(tags: $tags) {
        id
        name
        capacity
        kind
        tags
        owner {
          id
          __typename
        }
        __typename
      }
      __typename
    }
    __typename
  }
}";

        // Cosmetics
        public static string SetActiveBadge = @"
mutation SetActiveBadge($id: Id!, $badgeId: Id) {
  users {
    user(id: $id) {
      activeBadge(badgeId: $badgeId) {
        id,
        style {
            activeBadge {
                id,
                name
            }
        }
      }
    }
  }
}";
        public static string SetActivePaint = @"
mutation SetActivePaint($id: Id!, $paintId: Id) {
  users {
    user(id: $id) {
      activePaint(paintId: $paintId) {
        id,
        style {
            activePaint {
                id,
                name
            }
        }
      }
    }
  }
}";
    }
}
