using System;
using Newtonsoft.Json;

namespace Spider.Lib.JsonLib {
    public class ModInfo {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("authors")]
        public Author[] Authors { get; set; }

        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }

        [JsonProperty("websiteUrl")]
        public Uri WebsiteUrl { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("defaultFileId")]
        public long DefaultFileId { get; set; }

        [JsonProperty("downloadCount")]
        public long DownloadCount { get; set; }

        [JsonProperty("latestFiles")]
        public LatestFile[] LatestFiles { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("primaryCategoryId")]
        public long PrimaryCategoryId { get; set; }

        [JsonProperty("categorySection")]
        public CategorySection CategorySection { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("gameVersionLatestFiles")]
        public GameVersionLatestFile[] GameVersionLatestFiles { get; set; }

        [JsonProperty("isFeatured")]
        public bool IsFeatured { get; set; }

        [JsonProperty("popularityScore")]
        public double PopularityScore { get; set; }

        [JsonProperty("gamePopularityRank")]
        public long GamePopularityRank { get; set; }

        [JsonProperty("primaryLanguage")]
        public string PrimaryLanguage { get; set; }

        [JsonProperty("gameSlug")]
        public string GameSlug { get; set; }

        [JsonProperty("gameName")]
        public string GameName { get; set; }

        [JsonProperty("portalName")]
        public string PortalName { get; set; }

        [JsonProperty("dateModified")]
        public DateTimeOffset DateModified { get; set; }

        [JsonProperty("dateCreated")]
        public DateTimeOffset DateCreated { get; set; }

        [JsonProperty("dateReleased")]
        public DateTimeOffset DateReleased { get; set; }

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty("isExperiemental")]
        public bool IsExperiemental { get; set; }
    }

    public class Attachment {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("thumbnailUrl")]
        public Uri ThumbnailUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }
    }

    public class Author {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("projectTitleId")]
        public long? ProjectTitleId { get; set; }

        [JsonProperty("projectTitleTitle")]
        public string ProjectTitleTitle { get; set; }

        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("twitchId")]
        public long? TwitchId { get; set; }
    }

    public class Category {
        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("parentId")]
        public long ParentId { get; set; }

        [JsonProperty("rootId")]
        public long RootId { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }
    }

    public class CategorySection {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("packageType")]
        public long PackageType { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("initialInclusionPattern")]
        public string InitialInclusionPattern { get; set; }

        [JsonProperty("extraIncludePattern")]
        public object ExtraIncludePattern { get; set; }

        [JsonProperty("gameCategoryId")]
        public long GameCategoryId { get; set; }
    }

    public class GameVersionLatestFile {
        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("projectFileId")]
        public long ProjectFileId { get; set; }

        [JsonProperty("projectFileName")]
        public string ProjectFileName { get; set; }

        [JsonProperty("fileType")]
        public long FileType { get; set; }

        [JsonProperty("gameVersionFlavor")]
        public object GameVersionFlavor { get; set; }
    }

    public class LatestFile {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("fileDate")]
        public DateTimeOffset FileDate { get; set; }

        [JsonProperty("fileLength")]
        public long FileLength { get; set; }

        [JsonProperty("releaseType")]
        public long ReleaseType { get; set; }

        [JsonProperty("fileStatus")]
        public long FileStatus { get; set; }

        [JsonProperty("downloadUrl")]
        public Uri DownloadUrl { get; set; }

        [JsonProperty("isAlternate")]
        public bool IsAlternate { get; set; }

        [JsonProperty("alternateFileId")]
        public long AlternateFileId { get; set; }

        [JsonProperty("dependencies")]
        public Dependency[] Dependencies { get; set; }

        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty("modules")]
        public Module[] Modules { get; set; }

        [JsonProperty("packageFingerprint")]
        public long PackageFingerprint { get; set; }

        [JsonProperty("gameVersion")]
        public string[] GameVersion { get; set; }

        [JsonProperty("sortableGameVersion")]
        public SortableGameVersion[] SortableGameVersion { get; set; }

        [JsonProperty("installMetadata")]
        public object InstallMetadata { get; set; }

        [JsonProperty("changelog")]
        public object Changelog { get; set; }

        [JsonProperty("hasInstallScript")]
        public bool HasInstallScript { get; set; }

        [JsonProperty("isCompatibleWithClient")]
        public bool IsCompatibleWithClient { get; set; }

        [JsonProperty("categorySectionPackageType")]
        public long CategorySectionPackageType { get; set; }

        [JsonProperty("restrictProjectFileAccess")]
        public long RestrictProjectFileAccess { get; set; }

        [JsonProperty("projectStatus")]
        public long ProjectStatus { get; set; }

        [JsonProperty("renderCacheId")]
        public long RenderCacheId { get; set; }

        [JsonProperty("fileLegacyMappingId")]
        public object FileLegacyMappingId { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("parentProjectFileId")]
        public object ParentProjectFileId { get; set; }

        [JsonProperty("parentFileLegacyMappingId")]
        public object ParentFileLegacyMappingId { get; set; }

        [JsonProperty("fileTypeId")]
        public object FileTypeId { get; set; }

        [JsonProperty("exposeAsAlternative")]
        public object ExposeAsAlternative { get; set; }

        [JsonProperty("packageFingerprintId")]
        public long PackageFingerprintId { get; set; }

        [JsonProperty("gameVersionDateReleased")]
        public DateTimeOffset GameVersionDateReleased { get; set; }

        [JsonProperty("gameVersionMappingId")]
        public long GameVersionMappingId { get; set; }

        [JsonProperty("gameVersionId")]
        public long GameVersionId { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("isServerPack")]
        public bool IsServerPack { get; set; }

        [JsonProperty("serverPackFileId")]
        public object ServerPackFileId { get; set; }

        [JsonProperty("gameVersionFlavor")]
        public object GameVersionFlavor { get; set; }
    }

    public class Dependency {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("addonId")]
        public long AddonId { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("fileId")]
        public long FileId { get; set; }
    }

    public class Module {
        [JsonProperty("foldername")]
        public string Foldername { get; set; }

        [JsonProperty("fingerprint")]
        public long Fingerprint { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class SortableGameVersion {
        [JsonProperty("gameVersionPadded")]
        public string GameVersionPadded { get; set; }

        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("gameVersionReleaseDate")]
        public DateTimeOffset GameVersionReleaseDate { get; set; }

        [JsonProperty("gameVersionName")]
        public string GameVersionName { get; set; }
    }
}