using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Xml;

[assembly: global::System.Reflection.AssemblyVersion("4.0.0.0")]



namespace System.Runtime.Serialization.Generated
{
    [global::System.Runtime.CompilerServices.__BlockReflection]
    public static partial class DataContractSerializerHelper
    {
        public static void InitDataContracts()
        {
            global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Runtime.Serialization.DataContract> dataContracts = global::System.Runtime.Serialization.DataContract.GetDataContracts();
            PopulateContractDictionary(dataContracts);
            global::System.Collections.Generic.Dictionary<global::System.Runtime.Serialization.DataContract, global::System.Runtime.Serialization.Json.JsonReadWriteDelegates> jsonDelegates = global::System.Runtime.Serialization.Json.JsonReadWriteDelegates.GetJsonDelegates();
            PopulateJsonDelegateDictionary(
                                dataContracts, 
                                jsonDelegates
                            );
        }
        static int[] s_knownContractsLists = new int[] {
              -1, }
        ;
        // Count = 272
        static int[] s_xmlDictionaryStrings = new int[] {
                0, // array length: 0
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                -1, // string: null
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                708, // index: 708, string: "TrackId"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                -1, // string: null
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                716, // index: 716, string: "Timestamp"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                -1, // string: null
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                716, // index: 716, string: "Timestamp"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                1, // array length: 1
                726, // index: 726, string: "Songs"
                1, // array length: 1
                289, // index: 289, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages"
                43, // array length: 43
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                43, // array length: 43
                732, // index: 732, string: "AlbumArtUri"
                744, // index: 744, string: "artwork_url"
                756, // index: 756, string: "attachments_uri"
                772, // index: 772, string: "bpm"
                776, // index: 776, string: "comment_count"
                790, // index: 790, string: "commentable"
                802, // index: 802, string: "created_at"
                813, // index: 813, string: "created_with"
                826, // index: 826, string: "description"
                838, // index: 838, string: "download_count"
                853, // index: 853, string: "download_url"
                866, // index: 866, string: "downloadable"
                187, // index: 187, string: "duration"
                879, // index: 879, string: "favoritings_count"
                897, // index: 897, string: "genre"
                903, // index: 903, string: "id"
                906, // index: 906, string: "isrc"
                911, // index: 911, string: "key_signature"
                925, // index: 925, string: "label_id"
                934, // index: 934, string: "label_name"
                945, // index: 945, string: "license"
                953, // index: 953, string: "original_content_size"
                975, // index: 975, string: "original_format"
                991, // index: 991, string: "permalink"
                1001, // index: 1001, string: "permalink_url"
                1015, // index: 1015, string: "playback_count"
                1030, // index: 1030, string: "purchase_url"
                1043, // index: 1043, string: "release"
                1051, // index: 1051, string: "release_day"
                1063, // index: 1063, string: "release_month"
                1077, // index: 1077, string: "release_year"
                1090, // index: 1090, string: "sharing"
                1098, // index: 1098, string: "state"
                1104, // index: 1104, string: "stream_url"
                1115, // index: 1115, string: "streamable"
                1126, // index: 1126, string: "tag_list"
                1135, // index: 1135, string: "title"
                1141, // index: 1141, string: "track_type"
                1152, // index: 1152, string: "uri"
                1156, // index: 1156, string: "user"
                1161, // index: 1161, string: "user_id"
                1169, // index: 1169, string: "video_url"
                1179, // index: 1179, string: "waveform_url"
                43, // array length: 43
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                4, // array length: 4
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                4, // array length: 4
                903, // index: 903, string: "id"
                1192, // index: 1192, string: "name"
                1001, // index: 1001, string: "permalink_url"
                1152, // index: 1152, string: "uri"
                4, // array length: 4
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                25, // array length: 25
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                -1, // string: null
                1, // array length: 1
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                25, // array length: 25
                1197, // index: 1197, string: "avatar_url"
                1208, // index: 1208, string: "city"
                1213, // index: 1213, string: "country"
                826, // index: 826, string: "description"
                1221, // index: 1221, string: "discogs_name"
                1234, // index: 1234, string: "first_name"
                1245, // index: 1245, string: "followers_count"
                1261, // index: 1261, string: "followings_count"
                1278, // index: 1278, string: "full_name"
                903, // index: 903, string: "id"
                1288, // index: 1288, string: "kind"
                1293, // index: 1293, string: "last_modified"
                1307, // index: 1307, string: "last_name"
                1317, // index: 1317, string: "myspace_name"
                1330, // index: 1330, string: "online"
                991, // index: 991, string: "permalink"
                1001, // index: 1001, string: "permalink_url"
                1337, // index: 1337, string: "plan"
                1342, // index: 1342, string: "playlist_count"
                1357, // index: 1357, string: "public_favorites_count"
                1380, // index: 1380, string: "track_count"
                1152, // index: 1152, string: "uri"
                1392, // index: 1392, string: "username"
                1401, // index: 1401, string: "website"
                1409, // index: 1409, string: "website_title"
                25, // array length: 25
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520, // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
                520  // index: 520, string: "http://schemas.datacontract.org/2004/07/BackgroundAudioShared"
        };
        // Count = 0
        static global::MemberEntry[] s_dataMemberLists = new global::MemberEntry[0];
        static readonly byte[] s_dataContractMap_Hashtable = null;
        // Count=50
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::DataContractMapEntry[] s_dataContractMap = new global::DataContractMapEntry[] {
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 0, // 0x0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]" +
                                ", mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 0, // 0x0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 16, // 0x10
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 32, // 0x20
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 32, // 0x20
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 48, // 0x30
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]" +
                                "], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 48, // 0x30
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 64, // 0x40
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]" +
                                ", mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 64, // 0x40
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 80, // 0x50
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 80, // 0x50
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 96, // 0x60
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 96, // 0x60
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 112, // 0x70
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 112, // 0x70
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 128, // 0x80
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 128, // 0x80
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 144, // 0x90
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 144, // 0x90
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 160, // 0xa0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Xml.ReaderWriter, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f" +
                                "11d50a3a")),
                    TableIndex = 176, // 0xb0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 192, // 0xc0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 192, // 0xc0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 208, // 0xd0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], " +
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 208, // 0xd0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 224, // 0xe0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 240, // 0xf0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]" +
                                "], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 240, // 0xf0
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 256, // 0x100
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], m" +
                                "scorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 256, // 0x100
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 272, // 0x110
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 272, // 0x110
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 288, // 0x120
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 288, // 0x120
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 304, // 0x130
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Nullable`1[[System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]," +
                                " mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    TableIndex = 304, // 0x130
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 320, // 0x140
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.BackgroundAudioTaskStartedMessage, BackgroundAudioShared, Version=1.0.0.0, Cultur" +
                                "e=neutral, PublicKeyToken=null")),
                    TableIndex = 1, // 0x1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.TrackChangedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                "licKeyToken=null")),
                    TableIndex = 17, // 0x11
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.AppSuspendedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                "licKeyToken=null")),
                    TableIndex = 33, // 0x21
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.AppResumedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Publi" +
                                "cKeyToken=null")),
                    TableIndex = 49, // 0x31
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.StartPlaybackMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pu" +
                                "blicKeyToken=null")),
                    TableIndex = 65, // 0x41
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.SkipNextMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicK" +
                                "eyToken=null")),
                    TableIndex = 81, // 0x51
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.SkipPreviousMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                "licKeyToken=null")),
                    TableIndex = 97, // 0x61
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.UpdatePlaylistMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, P" +
                                "ublicKeyToken=null")),
                    TableIndex = 113, // 0x71
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[BackgroundAudioShared.SoundCloudTrack, BackgroundAudioShared, Version=1.0.0.0" +
                                ", Culture=neutral, PublicKeyToken=null]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken" +
                                "=b03f5f7f11d50a3a")),
                    TableIndex = 2, // 0x2
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudTrack, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n" +
                                "ull")),
                    TableIndex = 129, // 0x81
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudCreatedWith, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyT" +
                                "oken=null")),
                    TableIndex = 145, // 0x91
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudUser, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nu" +
                                "ll")),
                    TableIndex = 161, // 0xa1
                }, 
                new global::DataContractMapEntry() {
                    UserCodeType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    TableIndex = 18, // 0x12
                }
        };
        static readonly byte[] s_dataContracts_Hashtable = null;
        // Count=21
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::DataContractEntry[] s_dataContracts = new global::DataContractEntry[] {
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 0, // boolean
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 0, // boolean
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 0, // boolean
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.BooleanDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 93, // base64Binary
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 93, // base64Binary
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 93, // base64Binary
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.ByteArrayDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 106, // char
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 106, // char
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 106, // char
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Char, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.CharDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 111, // dateTime
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 111, // dateTime
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 111, // dateTime
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DateTimeDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 120, // decimal
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 120, // decimal
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 120, // decimal
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DecimalDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 128, // double
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 128, // double
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 128, // double
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.DoubleDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 135, // float
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 135, // float
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 135, // float
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.FloatDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 141, // guid
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 141, // guid
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 141, // guid
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Guid, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.GuidDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 146, // int
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 146, // int
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 146, // int
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.IntDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 150, // long
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 150, // long
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 150, // long
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.LongDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 155, // anyType
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 155, // anyType
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 155, // anyType
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    Kind = global::DataContractKind.ObjectDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 163, // QName
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 163, // QName
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 163, // QName
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Xml.ReaderWriter, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f" +
                                    "11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Xml.XmlQualifiedName, System.Xml.ReaderWriter, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f" +
                                    "11d50a3a")),
                    },
                    Kind = global::DataContractKind.QNameDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 169, // short
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 169, // short
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 169, // short
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.ShortDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 175, // byte
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 175, // byte
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 175, // byte
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.SByte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.SignedByteDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 180, // string
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 180, // string
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 180, // string
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.StringDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 187, // duration
                        NamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        StableNameIndex = 187, // duration
                        StableNameNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        TopLevelElementNameIndex = 187, // duration
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.TimeSpan, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.TimeSpanDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 196, // unsignedByte
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 196, // unsignedByte
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 196, // unsignedByte
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Byte, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedByteDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 209, // unsignedInt
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 209, // unsignedInt
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 209, // unsignedInt
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedIntDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 221, // unsignedLong
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 221, // unsignedLong
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 221, // unsignedLong
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedLongDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        IsValueType = true,
                        NameIndex = 234, // unsignedShort
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 234, // unsignedShort
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 234, // unsignedShort
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.UInt16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")),
                    },
                    Kind = global::DataContractKind.UnsignedShortDataContract,
                }, 
                new global::DataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        IsBuiltInDataContract = true,
                        NameIndex = 248, // anyURI
                        NamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        StableNameIndex = 248, // anyURI
                        StableNameNamespaceIndex = 8, // http://www.w3.org/2001/XMLSchema
                        TopLevelElementNameIndex = 248, // anyURI
                        TopLevelElementNamespaceIndex = 41, // http://schemas.microsoft.com/2003/10/Serialization/
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Uri, System.Private.Uri, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    Kind = global::DataContractKind.UriDataContract,
                }
        };
        static readonly byte[] s_classDataContracts_Hashtable = null;
        // Count=11
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::ClassDataContractEntry[] s_classDataContracts = new global::ClassDataContractEntry[] {
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 255, // BackgroundAudioTaskStartedMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 255, // BackgroundAudioTaskStartedMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 255, // BackgroundAudioTaskStartedMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.BackgroundAudioTaskStartedMessage, BackgroundAudioShared, Version=1.0.0.0, Cultur" +
                                    "e=neutral, PublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.BackgroundAudioTaskStartedMessage, BackgroundAudioShared, Version=1.0.0.0, Cultur" +
                                    "e=neutral, PublicKeyToken=null")),
                    },
                    HasDataContract = true,
                    ContractNamespacesListIndex = 1,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 360, // TrackChangedMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 360, // TrackChangedMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 360, // TrackChangedMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.TrackChangedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                    "licKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.TrackChangedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                    "licKeyToken=null")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 3,
                    ContractNamespacesListIndex = 5,
                    MemberNamesListIndex = 7,
                    MemberNamespacesListIndex = 9,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 380, // AppSuspendedMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 380, // AppSuspendedMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 380, // AppSuspendedMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.AppSuspendedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                    "licKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.AppSuspendedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                    "licKeyToken=null")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 11,
                    ContractNamespacesListIndex = 13,
                    MemberNamesListIndex = 15,
                    MemberNamespacesListIndex = 17,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 400, // AppResumedMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 400, // AppResumedMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 400, // AppResumedMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.AppResumedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Publi" +
                                    "cKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.AppResumedMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Publi" +
                                    "cKeyToken=null")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 19,
                    ContractNamespacesListIndex = 21,
                    MemberNamesListIndex = 23,
                    MemberNamespacesListIndex = 25,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 418, // StartPlaybackMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 418, // StartPlaybackMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 418, // StartPlaybackMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.StartPlaybackMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pu" +
                                    "blicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.StartPlaybackMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pu" +
                                    "blicKeyToken=null")),
                    },
                    HasDataContract = true,
                    ContractNamespacesListIndex = 27,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 439, // SkipNextMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 439, // SkipNextMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 439, // SkipNextMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.SkipNextMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicK" +
                                    "eyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.SkipNextMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicK" +
                                    "eyToken=null")),
                    },
                    HasDataContract = true,
                    ContractNamespacesListIndex = 29,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 455, // SkipPreviousMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 455, // SkipPreviousMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 455, // SkipPreviousMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.SkipPreviousMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                    "licKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.SkipPreviousMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, Pub" +
                                    "licKeyToken=null")),
                    },
                    HasDataContract = true,
                    ContractNamespacesListIndex = 31,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 475, // UpdatePlaylistMessage
                        NamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        StableNameIndex = 475, // UpdatePlaylistMessage
                        StableNameNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        TopLevelElementNameIndex = 475, // UpdatePlaylistMessage
                        TopLevelElementNamespaceIndex = 289, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared.Messages
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.UpdatePlaylistMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, P" +
                                    "ublicKeyToken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.Messages.UpdatePlaylistMessage, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, P" +
                                    "ublicKeyToken=null")),
                    },
                    HasDataContract = true,
                    ChildElementNamespacesListIndex = 33,
                    ContractNamespacesListIndex = 35,
                    MemberNamesListIndex = 37,
                    MemberNamespacesListIndex = 39,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 582, // SoundCloudTrack
                        NamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        StableNameIndex = 582, // SoundCloudTrack
                        StableNameNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        TopLevelElementNameIndex = 582, // SoundCloudTrack
                        TopLevelElementNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudTrack, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n" +
                                    "ull")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudTrack, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n" +
                                    "ull")),
                    },
                    ChildElementNamespacesListIndex = 41,
                    ContractNamespacesListIndex = 85,
                    MemberNamesListIndex = 87,
                    MemberNamespacesListIndex = 131,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 598, // SoundCloudCreatedWith
                        NamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        StableNameIndex = 598, // SoundCloudCreatedWith
                        StableNameNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        TopLevelElementNameIndex = 598, // SoundCloudCreatedWith
                        TopLevelElementNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudCreatedWith, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyT" +
                                    "oken=null")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudCreatedWith, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyT" +
                                    "oken=null")),
                    },
                    ChildElementNamespacesListIndex = 175,
                    ContractNamespacesListIndex = 180,
                    MemberNamesListIndex = 182,
                    MemberNamespacesListIndex = 187,
                }, 
                new global::ClassDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 620, // SoundCloudUser
                        NamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        StableNameIndex = 620, // SoundCloudUser
                        StableNameNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        TopLevelElementNameIndex = 620, // SoundCloudUser
                        TopLevelElementNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudUser, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nu" +
                                    "ll")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudUser, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nu" +
                                    "ll")),
                    },
                    ChildElementNamespacesListIndex = 192,
                    ContractNamespacesListIndex = 218,
                    MemberNamesListIndex = 220,
                    MemberNamespacesListIndex = 246,
                }
        };
        static readonly byte[] s_collectionDataContracts_Hashtable = null;
        // Count=2
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::CollectionDataContractEntry[] s_collectionDataContracts = new global::CollectionDataContractEntry[] {
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 497, // ArrayOfSoundCloudTrack
                        NamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        StableNameIndex = 497, // ArrayOfSoundCloudTrack
                        StableNameNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        TopLevelElementNameIndex = 497, // ArrayOfSoundCloudTrack
                        TopLevelElementNamespaceIndex = 520, // http://schemas.datacontract.org/2004/07/BackgroundAudioShared
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[BackgroundAudioShared.SoundCloudTrack, BackgroundAudioShared, Version=1.0.0.0" +
                                    ", Culture=neutral, PublicKeyToken=null]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken" +
                                    "=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1[[BackgroundAudioShared.SoundCloudTrack, BackgroundAudioShared, Version=1.0.0.0" +
                                    ", Culture=neutral, PublicKeyToken=null]], System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken" +
                                    "=b03f5f7f11d50a3a")),
                        GenericTypeDefinition = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Collections.Generic.List`1, System.Collections, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7" +
                                    "f11d50a3a")),
                    },
                    CollectionItemNameIndex = 582, // SoundCloudTrack
                    KeyNameIndex = -1,
                    ItemNameIndex = 582, // SoundCloudTrack
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.GenericList,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("BackgroundAudioShared.SoundCloudTrack, BackgroundAudioShared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=n" +
                                "ull")),
                }, 
                new global::CollectionDataContractEntry() {
                    Common = new global::CommonContractEntry() {
                        HasRoot = true,
                        NameIndex = 635, // ArrayOfanyType
                        NamespaceIndex = 650, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        StableNameIndex = 635, // ArrayOfanyType
                        StableNameNamespaceIndex = 650, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        TopLevelElementNameIndex = 635, // ArrayOfanyType
                        TopLevelElementNamespaceIndex = 650, // http://schemas.microsoft.com/2003/10/Serialization/Arrays
                        OriginalUnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                        UnderlyingType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object[], System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                    },
                    CollectionItemNameIndex = 155, // anyType
                    KeyNameIndex = -1,
                    ItemNameIndex = 155, // anyType
                    ValueNameIndex = -1,
                    CollectionContractKind = global::System.Runtime.Serialization.CollectionKind.Array,
                    ItemType = new global::Internal.Runtime.CompilerServices.FixupRuntimeTypeHandle(global::System.Runtime.InteropServices.TypeOfHelper.RuntimeTypeHandleOf("System.Object, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")),
                }
        };
        static readonly byte[] s_enumDataContracts_Hashtable = null;
        // Count=0
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::EnumDataContractEntry[] s_enumDataContracts = new global::EnumDataContractEntry[0];
        static readonly byte[] s_xmlDataContracts_Hashtable = null;
        // Count=0
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::XmlDataContractEntry[] s_xmlDataContracts = new global::XmlDataContractEntry[0];
        static readonly byte[] s_jsonDelegatesList_Hashtable = null;
        // Count=13
        [global::System.Runtime.CompilerServices.PreInitialized]
        static readonly global::JsonDelegateEntry[] s_jsonDelegatesList = new global::JsonDelegateEntry[] {
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 37,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type3.WriteBackgroundAudioTaskStartedMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type2.ReadBackgroundAudioTaskStartedMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 38,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type7.WriteTrackChangedMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type6.ReadTrackChangedMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 39,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type11.WriteAppSuspendedMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type10.ReadAppSuspendedMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 40,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type15.WriteAppResumedMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type14.ReadAppResumedMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 41,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type19.WriteStartPlaybackMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type18.ReadStartPlaybackMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 42,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type23.WriteSkipNextMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type22.ReadSkipNextMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 43,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type27.WriteSkipPreviousMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type26.ReadSkipPreviousMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 44,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type31.WriteUpdatePlaylistMessageToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type30.ReadUpdatePlaylistMessageFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 45,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type36.WriteArrayOfSoundCloudTrackToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type35.ReadArrayOfSoundCloudTrackFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type37.ReadArrayOfSoundCloudTrackFromJsonIsGetOnly),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 46,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type41.WriteSoundCloudTrackToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type40.ReadSoundCloudTrackFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 47,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type45.WriteSoundCloudCreatedWithToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type44.ReadSoundCloudCreatedWithFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 48,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassWriterDelegate>(global::Type49.WriteSoundCloudUserToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatClassReaderDelegate>(global::Type48.ReadSoundCloudUserFromJson),
                }, 
                new global::JsonDelegateEntry() {
                    DataContractMapIndex = 49,
                    IsCollection = true,
                    WriterDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionWriterDelegate>(global::Type54.WriteArrayOfanyTypeToJson),
                    ReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatCollectionReaderDelegate>(global::Type53.ReadArrayOfanyTypeFromJson),
                    GetOnlyReaderDelegate = global::SgIntrinsics.AddrOf<global::System.Runtime.Serialization.Json.JsonFormatGetOnlyCollectionReaderDelegate>(global::Type55.ReadArrayOfanyTypeFromJsonIsGetOnly),
                }
        };
        static char[] s_stringPool = new char[] {
            'b','o','o','l','e','a','n','\0','h','t','t','p',':','/','/','w','w','w','.','w','3','.','o','r','g','/','2','0','0','1',
            '/','X','M','L','S','c','h','e','m','a','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','m','i','c','r',
            'o','s','o','f','t','.','c','o','m','/','2','0','0','3','/','1','0','/','S','e','r','i','a','l','i','z','a','t','i','o',
            'n','/','\0','b','a','s','e','6','4','B','i','n','a','r','y','\0','c','h','a','r','\0','d','a','t','e','T','i','m','e','\0',
            'd','e','c','i','m','a','l','\0','d','o','u','b','l','e','\0','f','l','o','a','t','\0','g','u','i','d','\0','i','n','t','\0',
            'l','o','n','g','\0','a','n','y','T','y','p','e','\0','Q','N','a','m','e','\0','s','h','o','r','t','\0','b','y','t','e','\0',
            's','t','r','i','n','g','\0','d','u','r','a','t','i','o','n','\0','u','n','s','i','g','n','e','d','B','y','t','e','\0','u',
            'n','s','i','g','n','e','d','I','n','t','\0','u','n','s','i','g','n','e','d','L','o','n','g','\0','u','n','s','i','g','n',
            'e','d','S','h','o','r','t','\0','a','n','y','U','R','I','\0','B','a','c','k','g','r','o','u','n','d','A','u','d','i','o',
            'T','a','s','k','S','t','a','r','t','e','d','M','e','s','s','a','g','e','\0','h','t','t','p',':','/','/','s','c','h','e',
            'm','a','s','.','d','a','t','a','c','o','n','t','r','a','c','t','.','o','r','g','/','2','0','0','4','/','0','7','/','B',
            'a','c','k','g','r','o','u','n','d','A','u','d','i','o','S','h','a','r','e','d','.','M','e','s','s','a','g','e','s','\0',
            'T','r','a','c','k','C','h','a','n','g','e','d','M','e','s','s','a','g','e','\0','A','p','p','S','u','s','p','e','n','d',
            'e','d','M','e','s','s','a','g','e','\0','A','p','p','R','e','s','u','m','e','d','M','e','s','s','a','g','e','\0','S','t',
            'a','r','t','P','l','a','y','b','a','c','k','M','e','s','s','a','g','e','\0','S','k','i','p','N','e','x','t','M','e','s',
            's','a','g','e','\0','S','k','i','p','P','r','e','v','i','o','u','s','M','e','s','s','a','g','e','\0','U','p','d','a','t',
            'e','P','l','a','y','l','i','s','t','M','e','s','s','a','g','e','\0','A','r','r','a','y','O','f','S','o','u','n','d','C',
            'l','o','u','d','T','r','a','c','k','\0','h','t','t','p',':','/','/','s','c','h','e','m','a','s','.','d','a','t','a','c',
            'o','n','t','r','a','c','t','.','o','r','g','/','2','0','0','4','/','0','7','/','B','a','c','k','g','r','o','u','n','d',
            'A','u','d','i','o','S','h','a','r','e','d','\0','S','o','u','n','d','C','l','o','u','d','T','r','a','c','k','\0','S','o',
            'u','n','d','C','l','o','u','d','C','r','e','a','t','e','d','W','i','t','h','\0','S','o','u','n','d','C','l','o','u','d',
            'U','s','e','r','\0','A','r','r','a','y','O','f','a','n','y','T','y','p','e','\0','h','t','t','p',':','/','/','s','c','h',
            'e','m','a','s','.','m','i','c','r','o','s','o','f','t','.','c','o','m','/','2','0','0','3','/','1','0','/','S','e','r',
            'i','a','l','i','z','a','t','i','o','n','/','A','r','r','a','y','s','\0','T','r','a','c','k','I','d','\0','T','i','m','e',
            's','t','a','m','p','\0','S','o','n','g','s','\0','A','l','b','u','m','A','r','t','U','r','i','\0','a','r','t','w','o','r',
            'k','_','u','r','l','\0','a','t','t','a','c','h','m','e','n','t','s','_','u','r','i','\0','b','p','m','\0','c','o','m','m',
            'e','n','t','_','c','o','u','n','t','\0','c','o','m','m','e','n','t','a','b','l','e','\0','c','r','e','a','t','e','d','_',
            'a','t','\0','c','r','e','a','t','e','d','_','w','i','t','h','\0','d','e','s','c','r','i','p','t','i','o','n','\0','d','o',
            'w','n','l','o','a','d','_','c','o','u','n','t','\0','d','o','w','n','l','o','a','d','_','u','r','l','\0','d','o','w','n',
            'l','o','a','d','a','b','l','e','\0','f','a','v','o','r','i','t','i','n','g','s','_','c','o','u','n','t','\0','g','e','n',
            'r','e','\0','i','d','\0','i','s','r','c','\0','k','e','y','_','s','i','g','n','a','t','u','r','e','\0','l','a','b','e','l',
            '_','i','d','\0','l','a','b','e','l','_','n','a','m','e','\0','l','i','c','e','n','s','e','\0','o','r','i','g','i','n','a',
            'l','_','c','o','n','t','e','n','t','_','s','i','z','e','\0','o','r','i','g','i','n','a','l','_','f','o','r','m','a','t',
            '\0','p','e','r','m','a','l','i','n','k','\0','p','e','r','m','a','l','i','n','k','_','u','r','l','\0','p','l','a','y','b',
            'a','c','k','_','c','o','u','n','t','\0','p','u','r','c','h','a','s','e','_','u','r','l','\0','r','e','l','e','a','s','e',
            '\0','r','e','l','e','a','s','e','_','d','a','y','\0','r','e','l','e','a','s','e','_','m','o','n','t','h','\0','r','e','l',
            'e','a','s','e','_','y','e','a','r','\0','s','h','a','r','i','n','g','\0','s','t','a','t','e','\0','s','t','r','e','a','m',
            '_','u','r','l','\0','s','t','r','e','a','m','a','b','l','e','\0','t','a','g','_','l','i','s','t','\0','t','i','t','l','e',
            '\0','t','r','a','c','k','_','t','y','p','e','\0','u','r','i','\0','u','s','e','r','\0','u','s','e','r','_','i','d','\0','v',
            'i','d','e','o','_','u','r','l','\0','w','a','v','e','f','o','r','m','_','u','r','l','\0','n','a','m','e','\0','a','v','a',
            't','a','r','_','u','r','l','\0','c','i','t','y','\0','c','o','u','n','t','r','y','\0','d','i','s','c','o','g','s','_','n',
            'a','m','e','\0','f','i','r','s','t','_','n','a','m','e','\0','f','o','l','l','o','w','e','r','s','_','c','o','u','n','t',
            '\0','f','o','l','l','o','w','i','n','g','s','_','c','o','u','n','t','\0','f','u','l','l','_','n','a','m','e','\0','k','i',
            'n','d','\0','l','a','s','t','_','m','o','d','i','f','i','e','d','\0','l','a','s','t','_','n','a','m','e','\0','m','y','s',
            'p','a','c','e','_','n','a','m','e','\0','o','n','l','i','n','e','\0','p','l','a','n','\0','p','l','a','y','l','i','s','t',
            '_','c','o','u','n','t','\0','p','u','b','l','i','c','_','f','a','v','o','r','i','t','e','s','_','c','o','u','n','t','\0',
            't','r','a','c','k','_','c','o','u','n','t','\0','u','s','e','r','n','a','m','e','\0','w','e','b','s','i','t','e','\0','w',
            'e','b','s','i','t','e','_','t','i','t','l','e','\0'};
    }
}
