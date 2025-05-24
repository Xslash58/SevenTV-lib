namespace SevenTV.GraphQL
{
    public static class Queries
    {
        public static string UserEditorOf = @"
query UserEditorFor($userId: Id!) {
  users {
    user(id: $userId) {
      editorFor {
        userId
        editorId
        user {
          id
          mainConnection {
            platformDisplayName
            platformAvatarUrl
            __typename
          }
          __typename
        }
        state
        permissions {
          superAdmin
          emoteSet {
            manage
            admin
            create
            __typename
          }
          emote {
            manage
            admin
            create
            transfer
            __typename
          }
          user {
            manageProfile
            manageEditors
            managePersonalEmoteSet
            manageBilling
            admin
            __typename
          }
          __typename
        }
        updatedAt
        __typename
      }
      __typename
    }
    __typename
  }
}";

        public static string UserInventory = @"
query UserInventory($id: Id!) {
  users {
    user(id: $id) {
      inventory {
        badges {
          to {
            badge {
              id
              name
              description
              images {
                url
                mime
                size
                scale
                width
                height
                frameCount
                __typename
              }
              __typename
            }
            __typename
          }
          __typename
        }
        paints {
          from {
            __typename
            ... on EntitlementNodeRole {
              role {
                id
                name
                __typename
              }
              __typename
            }
            ... on EntitlementNodeSubscriptionBenefit {
              subscriptionBenefit {
                id
                name
                __typename
              }
              __typename
            }
            ... on EntitlementNodeSpecialEvent {
              specialEvent {
                id
                name
                __typename
              }
              __typename
            }
          }
          to {
            paint {
              id
              name
              data {
                layers {
                  id
                  ty {
                    __typename
                    ... on PaintLayerTypeSingleColor {
                      color {
                        hex
                        __typename
                      }
                      __typename
                    }
                    ... on PaintLayerTypeLinearGradient {
                      angle
                      repeating
                      stops {
                        at
                        color {
                          hex
                          __typename
                        }
                        __typename
                      }
                      __typename
                    }
                    ... on PaintLayerTypeRadialGradient {
                      repeating
                      stops {
                        at
                        color {
                          hex
                          __typename
                        }
                        __typename
                      }
                      shape
                      __typename
                    }
                    ... on PaintLayerTypeImage {
                      images {
                        url
                        mime
                        size
                        scale
                        width
                        height
                        frameCount
                        __typename
                      }
                      __typename
                    }
                  }
                  opacity
                  __typename
                }
                shadows {
                  color {
                    hex
                    __typename
                  }
                  offsetX
                  offsetY
                  blur
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
        __typename
      }
      __typename
    }
    __typename
  }
}";

        public static string EmoteSearch = @"
query EmoteSearch($query: String, $tags: [String!]!, $sortBy: SortBy!, $filters: Filters, $page: Int, $perPage: Int!, $isDefaultSetSet: Boolean!, $defaultSetId: Id!) {
  emotes {
    search(
      query: $query
      tags: {tags: $tags, match: ANY}
      sort: {sortBy: $sortBy, order: DESCENDING}
      filters: $filters
      page: $page
      perPage: $perPage
    ) {
      items {
        id
        defaultName
        owner {
          mainConnection {
            platformDisplayName
            __typename
          }
          style {
            activePaint {
              id
              name
              data {
                layers {
                  id
                  ty {
                    __typename
                    ... on PaintLayerTypeSingleColor {
                      color {
                        hex
                        __typename
                      }
                      __typename
                    }
                    ... on PaintLayerTypeLinearGradient {
                      angle
                      repeating
                      stops {
                        at
                        color {
                          hex
                          __typename
                        }
                        __typename
                      }
                      __typename
                    }
                    ... on PaintLayerTypeRadialGradient {
                      repeating
                      stops {
                        at
                        color {
                          hex
                          __typename
                        }
                        __typename
                      }
                      shape
                      __typename
                    }
                    ... on PaintLayerTypeImage {
                      images {
                        url
                        mime
                        size
                        scale
                        width
                        height
                        frameCount
                        __typename
                      }
                      __typename
                    }
                  }
                  opacity
                  __typename
                }
                shadows {
                  color {
                    hex
                    __typename
                  }
                  offsetX
                  offsetY
                  blur
                  __typename
                }
                __typename
              }
              __typename
            }
            __typename
          }
          highestRoleColor {
            hex
            __typename
          }
          __typename
        }
        deleted
        flags {
          defaultZeroWidth
          private
          publicListed
          __typename
        }
        imagesPending
        images {
          url
          mime
          size
          scale
          width
          frameCount
          __typename
        }
        ranking(ranking: TRENDING_WEEKLY)
        inEmoteSets(emoteSetIds: [$defaultSetId]) @include(if: $isDefaultSetSet) {
          emoteSetId
          emote {
            id
            alias
            __typename
          }
          __typename
        }
        __typename
      }
      totalCount
      pageCount
      __typename
    }
    __typename
  }
}";
        public static string UserEditors = @"
query UserEditors($userId: Id!) {
  users {
    user(id: $userId) {
      editors {
        userId
        editorId
        editor {
          id
          mainConnection {
            platformDisplayName
            platformAvatarUrl
            __typename
          }
          style {
            activeProfilePicture {
              images {
                url
                mime
                size
                width
                height
                scale
                frameCount
                __typename
              }
              __typename
            }
            __typename
          }
          highestRoleColor {
            hex
            __typename
          }
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
    __typename
  }
}";
    }
}
