using System.Net.Http;
using System.Threading.Tasks;
using System;
using SevenTV.Types.GraphQL;
using SevenTV.GraphQL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace SevenTV.Clients
{
    public class GraphQLClient
    {
        private readonly HttpClient _http;

        public GraphQLClient(string? token = null)
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://7tv.io/v4/gql");
            
            if (!string.IsNullOrEmpty(token))
                _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public async Task<Response<T>> SendQueryAsync<T>(string query, object variables) where T : class
        {
            var payload = new
            {
                query,
                variables
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var res = await _http.PostAsync("", content);
            string raw = await res.Content.ReadAsStringAsync();

            var jobj = JObject.Parse(raw);

            var errorsToken = jobj["errors"];
            var errors = errorsToken != null
                ? errorsToken.ToObject<List<GraphQLError>>()
                : null;

            return new Response<T>
            {
                Data = jobj["data"]?.ToObject<T>(),
                Success = errors == null || errors.Count == 0,
                Errors = errors,
                raw = raw
            };
        }

        //Queries
        public async Task<Response<UserEditorForResponse>> GetUserEditorFor(string userId)
        {
            return await SendQueryAsync<UserEditorForResponse>(Queries.UserEditorOf, new
            {
                userId
            });
        }
        public async Task<Response<UserEditorsResponse>> GetUserEditors(string userId)
        {
            return await SendQueryAsync<UserEditorsResponse>(Queries.UserEditors, new
            {
                userId
            });
        }
        public async Task<Response<JObject>> GetUserInventory(string userId)
        {
            return await SendQueryAsync<JObject>(Queries.UserInventory, new
            {
                id = userId
            });
        }
        public async Task<Response<EmoteSearchResponse>> GetEmoteSearch(string query = "",
            int page = 1,
            int perPage = 72,
            string sortBy = "TOP_ALL_TIME",
            string[]? tags = null,
            bool isDefaultSetSet = false,
            string defaultSetId = "",
            bool? animated = null,
            bool? approvedPersonal = null,
            bool? defaultZeroWidth = null,
            bool? exactMatch = null
            )
        {
            return await SendQueryAsync<EmoteSearchResponse>(Queries.EmoteSearch, new
            {
                defaultSetId,
                filters = new
                {
                    animated,
                    approvedPersonal,
                    defaultZeroWidth,
                    exactMatch
                },
                isDefaultSetSet,
                page,
                perPage,
                query,
                sortBy,
                tags = tags == null ? Array.Empty<string>() : tags,
            });
        }
        public async Task<Response<EmoteSetEmoteSearchResponse>> GetEmoteIdFromSet(string query, string emoteSetId, int page = 1, int perPage = 1)
        {
            return await SendQueryAsync<EmoteSetEmoteSearchResponse>(Queries.EmoteIdFromSet, new
            {
                query,
                emoteSetId,
                page,
                perPage
            });
        }

        // Mutations
        public async Task<Response<AddEmoteResponse>> AddEmote(string emoteId, string emoteSetId, string? alias = null)
        {
            return await SendQueryAsync<AddEmoteResponse>(Mutations.AddEmote, new
            {
                emote = new
                {
                    emoteId,
                    alias = alias == null ? null : alias
                },
                setId = emoteSetId
            });
        }
        public async Task<Response<RemoveEmoteResponse>> RemoveEmote(string emoteId, string emoteSetId, string? emoteAlias = null)
        {
            return await SendQueryAsync<RemoveEmoteResponse>(Mutations.RemoveEmote, new
            {
                emote = new
                {
                    emoteId,
                    alias = emoteAlias
                },
                setId = emoteSetId
            });
        }
        public async Task<Response<RenameEmoteInSetResponse>> AliasEmote(string emoteId, string emoteSetId, string newAlias)
        {
            return await SendQueryAsync<RenameEmoteInSetResponse>(Mutations.AliasEmote, new
            {
                emote = new
                {
                    emoteId,
                },
                alias = newAlias,
                setId = emoteSetId
            });
        }

        public async Task<Response<AddEditorResponse>> AddEditor(string editorId, string userId, object? permissions = null)
        {
            if (permissions == null) 
                permissions = new
                {
                    superAdmin = false,
                    emote = new
                    {
                        admin = false,
                        create = false,
                        manage = false,
                        transfer = false
                    },
                    emoteSet = new
                    {
                        admin = false,
                        create = false,
                        manage = false,
                    },
                    user = new
                    {
                        admin = false,
                        manageBilling = false,
                        manageEditors = false,
                        managePersonalEmoteSet = false,
                        manageProfile = false
                    }
                };

            return await SendQueryAsync<AddEditorResponse>(Mutations.AddEditor, new
            {
                editorId,
                userId,
                permissions
            });
        }
        public async Task<Response<DeleteEditorResponse>> RemoveEditor(string editorId, string userId)
        {
            return await SendQueryAsync<DeleteEditorResponse>(Mutations.RemoveEditor, new
            {
                editorId,
                userId
            });
        }
        public async Task<Response<UpdateEditorPermissionsResponse>> UpdateEditor(string editorId, string userId, object? permissions = null)
        {
            if (permissions == null)
                permissions = new
                {
                    superAdmin = false,
                    emote = new
                    {
                        admin = false,
                        create = false,
                        manage = false,
                        transfer = false
                    },
                    emoteSet = new
                    {
                        admin = false,
                        create = false,
                        manage = false,
                    },
                    user = new
                    {
                        admin = false,
                        manageBilling = false,
                        manageEditors = false,
                        managePersonalEmoteSet = false,
                        manageProfile = false
                    }
                };

            return await SendQueryAsync<UpdateEditorPermissionsResponse>(Mutations.UpdateEditor, new
            {
                editorId,
                userId,
                permissions
            });
        }

        public async Task<Response<CreateEmoteSetResponse>> CreateEmoteSet(string name, string ownerId, string[]? tags = null)
        {
            return await SendQueryAsync<CreateEmoteSetResponse>(Mutations.CreateEmoteSet, new
            {
                name,
                ownerId,
                tags = tags == null ? Array.Empty<string>() : tags
            });
        }
        public async Task<Response<DeleteSetResponse>> DeleteEmoteSet(string emoteSetId)
        {
            return await SendQueryAsync<DeleteSetResponse>(Mutations.DeleteEmoteSet, new
            {
                id =  emoteSetId
            });
        }
        public async Task<Response<UpdateEmoteSetNameResponse>> UpdateEmoteSetName(string emoteSetId, string name)
        {
            return await SendQueryAsync<UpdateEmoteSetNameResponse>(Mutations.UpdateEmoteSetName, new
            {
                id = emoteSetId,
                name
            });
        }
        public async Task<Response<UpdateEmoteSetCapacityResponse>> UpdateEmoteSetCapacity(string emoteSetId, int capacity)
        {
            return await SendQueryAsync<UpdateEmoteSetCapacityResponse>(Mutations.UpdateEmoteSetCapacity, new
            {
                id = emoteSetId,
                capacity
            });
        }
        public async Task<Response<UpdateEmoteSetTagsResponse>> UpdateEmoteSetTags(string emoteSetId, string[] tags)
        {
            return await SendQueryAsync<UpdateEmoteSetTagsResponse>(Mutations.UpdateEmoteSetTags, new
            {
                id = emoteSetId,
                tags
            });
        }

        public async Task<Response<SetActiveBadgeResponse>> SetActiveBadge(string badgeId, string userId)
        {
            return await SendQueryAsync<SetActiveBadgeResponse>(Mutations.SetActiveBadge, new
            {
                badgeId,
                id = userId
            });
        }
        public async Task<Response<SetActivePaintResponse>> SetActivePaint(string paintId, string userId)
        {
            return await SendQueryAsync<SetActivePaintResponse>(Mutations.SetActivePaint, new
            {
                paintId,
                id = userId
            });
        }
    }

}
