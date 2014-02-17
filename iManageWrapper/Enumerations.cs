using iml = IManage;

namespace iManageWrapper
{
// ReSharper disable InconsistentNaming
    public enum imObjectType
    {
        imTypeAdditionalProperties = iml.imObjectType.imTypeAdditionalProperties,
        imTypeAdditionalProperty = iml.imObjectType.imTypeAdditionalProperty,
        imTypeAndQuery = iml.imObjectType.imTypeAndQuery,
        imTypeAttachment = iml.imObjectType.imTypeAttachment,
        imTypeAttachments = iml.imObjectType.imTypeAttachments,
        imTypeAttributeDefinition = iml.imObjectType.imTypeAttributeDefinition,
        imTypeAttributeDefinitions = iml.imObjectType.imTypeAttributeDefinitions,
        imTypeAttributeSelections = iml.imObjectType.imTypeAttributeSelections,
        imTypeBodiedFolder = iml.imObjectType.imTypeBodiedFolder,
        imTypeCancel = iml.imObjectType.imTypeCancel,
        imTypeCaptions = iml.imObjectType.imTypeCaptions,
        imTypeCheckinResult = iml.imObjectType.imTypeCheckinResult,
        imTypeConnectorFolder = iml.imObjectType.imTypeConnectorFolder,
        imTypeConnectorFolders = iml.imObjectType.imTypeConnectorFolders,
        imTypeContent = iml.imObjectType.imTypeContent,
        imTypeContents = iml.imObjectType.imTypeContents,
        imTypeContentShortcut = iml.imObjectType.imTypeContentShortcut,
        imTypeContentShortcuts = iml.imObjectType.imTypeContentShortcuts,
        imTypeControl = iml.imObjectType.imTypeControl,
        imTypeControls = iml.imObjectType.imTypeControls,
        imTypeCustomAttribute = iml.imObjectType.imTypeCustomAttribute,
        imTypeCustomAttributes = iml.imObjectType.imTypeCustomAttributes,
        imTypeCustomProperties = iml.imObjectType.imTypeCustomProperties,
        imTypeCustomProperty = iml.imObjectType.imTypeCustomProperty,
        imTypeDatabase = iml.imObjectType.imTypeDatabase,
        imTypeDatabases = iml.imObjectType.imTypeDatabases,
        imTypeDate = iml.imObjectType.imTypeDate,
        imTypeDateRange = iml.imObjectType.imTypeDateRange,
        imTypeDMS = iml.imObjectType.imTypeDMS,
        imTypeDocument = iml.imObjectType.imTypeDocument,
        imTypeDocumentClass = iml.imObjectType.imTypeDocumentClass,
        imTypeDocumentClasses = iml.imObjectType.imTypeDocumentClasses,
        imTypeDocumentFolder = iml.imObjectType.imTypeDocumentFolder,
        imTypeDocumentFolders = iml.imObjectType.imTypeDocumentFolders,
        imTypeDocumentHistory = iml.imObjectType.imTypeDocumentHistory,
        imTypeDocuments = iml.imObjectType.imTypeDocuments,
        imTypeDocumentSearchFolder = iml.imObjectType.imTypeDocumentSearchFolder,
        imTypeDocumentSearchFolders = iml.imObjectType.imTypeDocumentSearchFolders,
        imTypeDocumentType = iml.imObjectType.imTypeDocumentType,
        imTypeDocumentTypes = iml.imObjectType.imTypeDocumentTypes,
        imTypeEvent = iml.imObjectType.imTypeEvent,
        imTypeEventFolder = iml.imObjectType.imTypeEventFolder,
        imTypeEventFolders = iml.imObjectType.imTypeEventFolders,
        imTypeEventHandler = iml.imObjectType.imTypeEventHandler,
        imTypeEventHandlers = iml.imObjectType.imTypeEventHandlers,
        imTypeEvents = iml.imObjectType.imTypeEvents,
        imTypeEventSearchParameter = iml.imObjectType.imTypeEventSearchParameter,
        imTypeEventSearchParameters = iml.imObjectType.imTypeEventSearchParameters,
        imTypeFavoritesFolder = iml.imObjectType.imTypeFavoritesFolder,
        imTypeFavoritesFolders = iml.imObjectType.imTypeFavoritesFolders,
        imTypeFieldQuery = iml.imObjectType.imTypeFieldQuery,
        imTypeFolder = iml.imObjectType.imTypeFolder,
        imTypeFolders = iml.imObjectType.imTypeFolders,
        imTypeFolderSearchParameter = iml.imObjectType.imTypeFolderSearchParameter,
        imTypeFolderSearchParameters = iml.imObjectType.imTypeFolderSearchParameters,
        imTypeFolderShortcut = iml.imObjectType.imTypeFolderShortcut,
        imTypeFolderShortcuts = iml.imObjectType.imTypeFolderShortcuts,
        imTypeForm = iml.imObjectType.imTypeForm,
        imTypeForms = iml.imObjectType.imTypeForms,
        imTypeGenericBodiedFolder = iml.imObjectType.imTypeGenericBodiedFolder,
        imTypeGenericBodiedFolders = iml.imObjectType.imTypeGenericBodiedFolders,
        imTypeGroup = iml.imObjectType.imTypeGroup,
        imTypeGroupACL = iml.imObjectType.imTypeGroupACL,
        imTypeGroupACLs = iml.imObjectType.imTypeGroupACLs,
        imTypeGroups = iml.imObjectType.imTypeGroups,
        imTypeHasLocation = iml.imObjectType.imTypeHasLocation,
        imTypeHasProfile = iml.imObjectType.imTypeHasProfile,
        imTypeHasProfiles = iml.imObjectType.imTypeHasProfiles,
        imTypeHistoryList = iml.imObjectType.imTypeHistoryList,
        imTypeLaunchMethod = iml.imObjectType.imTypeLaunchMethod,
        imTypeLaunchMethods = iml.imObjectType.imTypeLaunchMethods,
        imTypeLinkListFolder = iml.imObjectType.imTypeLinkListFolder,
        imTypeLinkListFolders = iml.imObjectType.imTypeLinkListFolders,
        imTypeLocation = iml.imObjectType.imTypeLocation,
        imTypeMessage = iml.imObjectType.imTypeMessage,
        imTypeMessageFolder = iml.imObjectType.imTypeMessageFolder,
        imTypeMessageFolders = iml.imObjectType.imTypeMessageFolders,
        imTypeMessages = iml.imObjectType.imTypeMessages,
        imTypeMessageSearchParameter = iml.imObjectType.imTypeMessageSearchParameter,
        imTypeMessageSearchParameters = iml.imObjectType.imTypeMessageSearchParameters,
        imTypeNoteFolder = iml.imObjectType.imTypeNoteFolder,
        imTypeNoteFolders = iml.imObjectType.imTypeNoteFolders,
        imTypeObject = iml.imObjectType.imTypeObject,
        imTypeObjects = iml.imObjectType.imTypeObjects,
        imTypeObjectSort = iml.imObjectType.imTypeObjectSort,
        imTypeObjectTypes = iml.imObjectType.imTypeObjectTypes,
        imTypeOrQuery = iml.imObjectType.imTypeOrQuery,
        imTypeProfile = iml.imObjectType.imTypeProfile,
        imTypeProfiled = iml.imObjectType.imTypeProfiled,
        imTypeProfiledContent = iml.imObjectType.imTypeProfiledContent,
        imTypeProfiledFolder = iml.imObjectType.imTypeProfiledFolder,
        imTypeProfileError = iml.imObjectType.imTypeProfileError,
        imTypeProfileErrors = iml.imObjectType.imTypeProfileErrors,
        imTypeProfileFullTextSearchParameter = iml.imObjectType.imTypeProfileFullTextSearchParameter,
        imTypeProfiles = iml.imObjectType.imTypeProfiles,
        imTypeProfileSearchParameter = iml.imObjectType.imTypeProfileSearchParameter,
        imTypeProfileSearchParameters = iml.imObjectType.imTypeProfileSearchParameters,
        imTypeProfileUpdateResult = iml.imObjectType.imTypeProfileUpdateResult,
        imTypeQueries = iml.imObjectType.imTypeQueries,
        imTypeQuery = iml.imObjectType.imTypeQuery,
        imTypeRelatedDocuments = iml.imObjectType.imTypeRelatedDocuments,
        imTypeRelativeDate = iml.imObjectType.imTypeRelativeDate,
        imTypeRole = iml.imObjectType.imTypeRole,
        imTypeRoleEditCreate = iml.imObjectType.imTypeRoleEditCreate,
        imTypeRoleEditCreates = iml.imObjectType.imTypeRoleEditCreates,
        imTypeRoles = iml.imObjectType.imTypeRoles,
        imTypeRoleSearchProfile = iml.imObjectType.imTypeRoleSearchProfile,
        imTypeRoleSearchProfiles = iml.imObjectType.imTypeRoleSearchProfiles,
        imTypeRule = iml.imObjectType.imTypeRule,
        imTypeRuleEventType = iml.imObjectType.imTypeRuleEventType,
        imTypeRuleEventTypes = iml.imObjectType.imTypeRuleEventTypes,
        imTypeRules = iml.imObjectType.imTypeRules,
        imTypeSecurity = iml.imObjectType.imTypeSecurity,
        imTypeSecurityTemplate = iml.imObjectType.imTypeSecurityTemplate,
        imTypeSecurityTemplates = iml.imObjectType.imTypeSecurityTemplates,
        imTypeSession = iml.imObjectType.imTypeSession,
        imTypeSessions = iml.imObjectType.imTypeSessions,
        imTypeSessionSearchNotification = iml.imObjectType.imTypeSessionSearchNotification,
        imTypeStream = iml.imObjectType.imTypeStream,
        imTypeStrings = iml.imObjectType.imTypeStrings,
        imTypeSubscriptionFolder = iml.imObjectType.imTypeSubscriptionFolder,
        imTypeSubscriptionFolders = iml.imObjectType.imTypeSubscriptionFolders,
        imTypeSubscriptionFolderSearchParameters = iml.imObjectType.imTypeSubscriptionFolderSearchParameters,
        imTypeSubscriptionFolderShortcuts = iml.imObjectType.imTypeSubscriptionFolderShortcuts,
        imTypeSyncResult = iml.imObjectType.imTypeSyncResult,
        imTypeTab = iml.imObjectType.imTypeTab,
        imTypeTabContents = iml.imObjectType.imTypeTabContents,
        imTypeTabs = iml.imObjectType.imTypeTabs,
        imTypeTask = iml.imObjectType.imTypeTask,
        imTypeTaskFolder = iml.imObjectType.imTypeTaskFolder,
        imTypeTaskFolders = iml.imObjectType.imTypeTaskFolders,
        imTypeTasks = iml.imObjectType.imTypeTasks,
        imTypeTaskSearchParameter = iml.imObjectType.imTypeTaskSearchParameter,
        imTypeTaskSearchParameters = iml.imObjectType.imTypeTaskSearchParameters,
        imTypeType = iml.imObjectType.imTypeType,
        imTypeUser = iml.imObjectType.imTypeUser,
        imTypeUserACL = iml.imObjectType.imTypeUserACL,
        imTypeUserACLs = iml.imObjectType.imTypeUserACLs,
        imTypeUserPreferences = iml.imObjectType.imTypeUserPreferences,
        imTypeUsers = iml.imObjectType.imTypeUsers,
        imTypeWorkArea = iml.imObjectType.imTypeWorkArea,
        imTypeWorkspace = iml.imObjectType.imTypeWorkspace,
        imTypeWorkspaces = iml.imObjectType.imTypeWorkspaces,
        imTypeWorkspaceSearchFolder = iml.imObjectType.imTypeWorkspaceSearchFolder,
        imTypeWorkspaceSearchFolders = iml.imObjectType.imTypeWorkspaceSearchFolders,
        imTypeWorkspaceSearchParameters = iml.imObjectType.imTypeWorkspaceSearchParameters,
        imTypeWorkspaceShortcuts = iml.imObjectType.imTypeWorkspaceShortcuts,
        imTypeNone = iml.imObjectType.imTypeNone,
        imTypeCacheableContent = iml.imObjectType.imTypeCacheableContent,
        imTypeContained = iml.imObjectType.imTypeContained,
        imTypeSyncPrefs = iml.imObjectType.imTypeSyncPrefs,
        imTypeWorkArea2 = iml.imObjectType.imTypeWorkArea2,
        imTypeFolderShortcut2 = iml.imObjectType.imTypeFolderShortcut2,
        imTypeDMS2 = iml.imObjectType.imTypeDMS2,
        imTypeDatabaseStats = iml.imObjectType.imTypeDatabaseStats,
        imTypeSessionStats = iml.imObjectType.imTypeSessionStats,
        imTypeFolderMapping = iml.imObjectType.imTypeFolderMapping,
        imTypeFolderMappings = iml.imObjectType.imTypeFolderMappings,
        imTypeFilingRequest = iml.imObjectType.imTypeFilingRequest,
        imTypeFilingRequests = iml.imObjectType.imTypeFilingRequests,
        imTypeArtifact = iml.imObjectType.imTypeArtifact,
        imTypeEMFilingRequest = iml.imObjectType.imTypeEMFilingRequest,
        imTypeEMFilingRequests = iml.imObjectType.imTypeEMFilingRequests,
        imTypeEMFolderMapping = iml.imObjectType.imTypeEMFolderMapping,
        imTypeEMFolderMappings = iml.imObjectType.imTypeEMFolderMappings,
        imTypeGOBSResult = iml.imObjectType.imTypeGOBSResult,
        imTypeDatabaseMeta = iml.imObjectType.imTypeDatabaseMeta,
        imTypeMetaDocumentShortcut = iml.imObjectType.imTypeMetaDocumentShortcut,
        imTypeMetaDocumentShortcuts = iml.imObjectType.imTypeMetaDocumentShortcuts,
        imTypeMetaDocument = iml.imObjectType.imTypeMetaDocument,
        imTypeMetaTuple = iml.imObjectType.imTypeMetaTuple,
        imTypeMetaTuples = iml.imObjectType.imTypeMetaTuples,
        imTypeSelectedAttributes = iml.imObjectType.imTypeSelectedAttributes
    }

    public enum imQueryType
    {
        imQueryField = iml.imQueryType.imQueryField,
        imQueryAnd = iml.imQueryType.imQueryAnd,
        imQueryOr = iml.imQueryType.imQueryOr,
        imQueryNot = iml.imQueryType.imQueryNot
    }

    public enum imProfileAttributeID
    {
        imProfileDatabase = iml.imProfileAttributeID.imProfileDatabase,
        imProfileDocNum = iml.imProfileAttributeID.imProfileDocNum,
        imProfileVersion = iml.imProfileAttributeID.imProfileVersion,
        imProfileDescription = iml.imProfileAttributeID.imProfileDescription,
        imProfileName = iml.imProfileAttributeID.imProfileName,
        imProfileAuthor = iml.imProfileAttributeID.imProfileAuthor,
        imProfileOperator = iml.imProfileAttributeID.imProfileOperator,
        imProfileType = iml.imProfileAttributeID.imProfileType,
        imProfileClass = iml.imProfileAttributeID.imProfileClass,
        imProfileSubClass = iml.imProfileAttributeID.imProfileSubClass,
        imProfileEditDate = iml.imProfileAttributeID.imProfileEditDate,
        imProfileCreateDate = iml.imProfileAttributeID.imProfileCreateDate,
        imProfileRetainDays = iml.imProfileAttributeID.imProfileRetainDays,
        imProfileSize = iml.imProfileAttributeID.imProfileSize,
        imProfileIndexable = iml.imProfileAttributeID.imProfileIndexable,
        imProfileIsRelated = iml.imProfileAttributeID.imProfileIsRelated,
        imProfileLocation = iml.imProfileAttributeID.imProfileLocation,
        imProfileDefaultSecurity = iml.imProfileAttributeID.imProfileDefaultSecurity,
        imProfileLastUser = iml.imProfileAttributeID.imProfileLastUser,
        imProfileInUseBy = iml.imProfileAttributeID.imProfileInUseBy,
        imProfileNetNode = iml.imProfileAttributeID.imProfileNetNode,
        imProfileInUse = iml.imProfileAttributeID.imProfileInUse,
        imProfileCheckedOut = iml.imProfileAttributeID.imProfileCheckedOut,
        imProfileArchived = iml.imProfileAttributeID.imProfileArchived,
        imProfileComment = iml.imProfileAttributeID.imProfileComment,
        imProfileCustom1 = iml.imProfileAttributeID.imProfileCustom1,
        imProfileCustom2 = iml.imProfileAttributeID.imProfileCustom2,
        imProfileCustom3 = iml.imProfileAttributeID.imProfileCustom3,
        imProfileCustom4 = iml.imProfileAttributeID.imProfileCustom4,
        imProfileCustom5 = iml.imProfileAttributeID.imProfileCustom5,
        imProfileCustom6 = iml.imProfileAttributeID.imProfileCustom6,
        imProfileCustom7 = iml.imProfileAttributeID.imProfileCustom7,
        imProfileCustom8 = iml.imProfileAttributeID.imProfileCustom8,
        imProfileCustom9 = iml.imProfileAttributeID.imProfileCustom9,
        imProfileCustom10 = iml.imProfileAttributeID.imProfileCustom10,
        imProfileCustom11 = iml.imProfileAttributeID.imProfileCustom11,
        imProfileCustom12 = iml.imProfileAttributeID.imProfileCustom12,
        imProfileCustom13 = iml.imProfileAttributeID.imProfileCustom13,
        imProfileCustom14 = iml.imProfileAttributeID.imProfileCustom14,
        imProfileCustom15 = iml.imProfileAttributeID.imProfileCustom15,
        imProfileCustom16 = iml.imProfileAttributeID.imProfileCustom16,
        imProfileCustom17 = iml.imProfileAttributeID.imProfileCustom17,
        imProfileCustom18 = iml.imProfileAttributeID.imProfileCustom18,
        imProfileCustom19 = iml.imProfileAttributeID.imProfileCustom19,
        imProfileCustom20 = iml.imProfileAttributeID.imProfileCustom20,
        imProfileCustom21 = iml.imProfileAttributeID.imProfileCustom21,
        imProfileCustom22 = iml.imProfileAttributeID.imProfileCustom22,
        imProfileCustom23 = iml.imProfileAttributeID.imProfileCustom23,
        imProfileCustom24 = iml.imProfileAttributeID.imProfileCustom24,
        imProfileCustom25 = iml.imProfileAttributeID.imProfileCustom25,
        imProfileCustom26 = iml.imProfileAttributeID.imProfileCustom26,
        imProfileCustom27 = iml.imProfileAttributeID.imProfileCustom27,
        imProfileCustom28 = iml.imProfileAttributeID.imProfileCustom28,
        imProfileCustom29 = iml.imProfileAttributeID.imProfileCustom29,
        imProfileCustom30 = iml.imProfileAttributeID.imProfileCustom30,
        imProfileCustom1Description = iml.imProfileAttributeID.imProfileCustom1Description,
        imProfileCustom2Description = iml.imProfileAttributeID.imProfileCustom2Description,
        imProfileCustom3Description = iml.imProfileAttributeID.imProfileCustom3Description,
        imProfileCustom4Description = iml.imProfileAttributeID.imProfileCustom4Description,
        imProfileCustom5Description = iml.imProfileAttributeID.imProfileCustom5Description,
        imProfileCustom6Description = iml.imProfileAttributeID.imProfileCustom6Description,
        imProfileCustom7Description = iml.imProfileAttributeID.imProfileCustom7Description,
        imProfileCustom8Description = iml.imProfileAttributeID.imProfileCustom8Description,
        imProfileCustom9Description = iml.imProfileAttributeID.imProfileCustom9Description,
        imProfileCustom10Description = iml.imProfileAttributeID.imProfileCustom10Description,
        imProfileCustom11Description = iml.imProfileAttributeID.imProfileCustom11Description,
        imProfileCustom12Description = iml.imProfileAttributeID.imProfileCustom12Description,
        imProfileCustom29Description = iml.imProfileAttributeID.imProfileCustom29Description,
        imProfileCustom30Description = iml.imProfileAttributeID.imProfileCustom30Description,
        imProfileAuthorDescription = iml.imProfileAttributeID.imProfileAuthorDescription,
        imProfileOperatorDescription = iml.imProfileAttributeID.imProfileOperatorDescription,
        imProfileTypeDescription = iml.imProfileAttributeID.imProfileTypeDescription,
        imProfileClassDescription = iml.imProfileAttributeID.imProfileClassDescription,
        imProfileSubClassDescription = iml.imProfileAttributeID.imProfileSubClassDescription,
        imProfileLastUserDescription = iml.imProfileAttributeID.imProfileLastUserDescription,
        imProfileInUseByDescription = iml.imProfileAttributeID.imProfileInUseByDescription,
        imProfileEditTime = iml.imProfileAttributeID.imProfileEditTime,
        imProfileExtension = iml.imProfileAttributeID.imProfileExtension,
        imProfileFullText = iml.imProfileAttributeID.imProfileFullText,
        imProfileSubType = iml.imProfileAttributeID.imProfileSubType,
        imProfileEditProfileTime = iml.imProfileAttributeID.imProfileEditProfileTime,
        imProfileContainerID = iml.imProfileAttributeID.imProfileContainerID,
        imProfileCustom31 = iml.imProfileAttributeID.imProfileCustom31,
        imProfileMarkedForArchive = iml.imProfileAttributeID.imProfileMarkedForArchive,
        imProfileEchoEnabled = iml.imProfileAttributeID.imProfileEchoEnabled,
        imProfileAccessTime = iml.imProfileAttributeID.imProfileAccessTime,
        imProfileMessageUniqueID = iml.imProfileAttributeID.imProfileMessageUniqueID,
        imProfileIsExternal = iml.imProfileAttributeID.imProfileIsExternal,
        imProfileHasAttachment = iml.imProfileAttributeID.imProfileHasAttachment,
        imProfileExternalAsNormal = iml.imProfileAttributeID.imProfileExternalAsNormal,
        imProfileProjectItemSID = iml.imProfileAttributeID.imProfileProjectItemSID,
        imProfileProjectItemParentSID = iml.imProfileAttributeID.imProfileProjectItemParentSID,
        imProfileCheckoutPath = iml.imProfileAttributeID.imProfileCheckoutPath,
        imProfileCheckoutDueDate = iml.imProfileAttributeID.imProfileCheckoutDueDate,
        imProfileCheckoutComments = iml.imProfileAttributeID.imProfileCheckoutComments,
        imProfileCheckoutWhen = iml.imProfileAttributeID.imProfileCheckoutWhen,
        imProfileQuickRetrieve = iml.imProfileAttributeID.imProfileQuickRetrieve,
        imProfileFrozen = iml.imProfileAttributeID.imProfileFrozen,
        imProfileDeclareDate = iml.imProfileAttributeID.imProfileDeclareDate,
        imProfileFileCreateDate = iml.imProfileAttributeID.imProfileFileCreateDate,
        imProfileFileModifyDate = iml.imProfileAttributeID.imProfileFileModifyDate,
        imProfileSystemCreateDate = iml.imProfileAttributeID.imProfileSystemCreateDate,
        imProfileSystemModifyDate = iml.imProfileAttributeID.imProfileSystemModifyDate,
        imProfileRestorable = iml.imProfileAttributeID.imProfileRestorable
    }

    public enum imAttributeType
    {
        imEmpty = iml.imAttributeType.imEmpty,
        imNull = iml.imAttributeType.imNull,
        imInteger = iml.imAttributeType.imInteger,
        imLong = iml.imAttributeType.imLong,
        imSingle = iml.imAttributeType.imSingle,
        imDouble = iml.imAttributeType.imDouble,
        imCurrency = iml.imAttributeType.imCurrency,
        imDate = iml.imAttributeType.imDate,
        imString = iml.imAttributeType.imString,
        imObject = iml.imAttributeType.imObject,
        imError = iml.imAttributeType.imError,
        imBoolean = iml.imAttributeType.imBoolean,
        imVariant = iml.imAttributeType.imVariant,
        imDataObject = iml.imAttributeType.imDataObject,
        imDecimal = iml.imAttributeType.imDecimal,
        imByte = iml.imAttributeType.imByte,
        imArray = iml.imAttributeType.imArray
    }

    public enum imContentsOp
    {
        imAddContentsOp = iml.imContentsOp.imAddContentsOp,
        imRemoveContentsOp = iml.imContentsOp.imRemoveContentsOp,
        imCheckInContentsOp = iml.imContentsOp.imCheckInContentsOp,
        imUpdateContentShortcutOp = iml.imContentsOp.imUpdateContentShortcutOp
    }

    public enum imFolderAttributeID
    {
        imFolderID = iml.imFolderAttributeID.imFolderID,
        imFolderParentID = iml.imFolderAttributeID.imFolderParentID,
        imFolderDefaultSecurity = iml.imFolderAttributeID.imFolderDefaultSecurity,
        imFolderName = iml.imFolderAttributeID.imFolderName,
        imFolderOwner = iml.imFolderAttributeID.imFolderOwner,
        imFolderDescription = iml.imFolderAttributeID.imFolderDescription,
        imFolderLocation = iml.imFolderAttributeID.imFolderLocation,
        imFolderType = iml.imFolderAttributeID.imFolderType,
        imFolderSubtype = iml.imFolderAttributeID.imFolderSubtype,
        imFolderInherits = iml.imFolderAttributeID.imFolderInherits,
        imFolderProfileID = iml.imFolderAttributeID.imFolderProfileID,
        imFolderVersion = iml.imFolderAttributeID.imFolderVersion,
        imFolderCustom1 = iml.imFolderAttributeID.imFolderCustom1,
        imFolderCustom2 = iml.imFolderAttributeID.imFolderCustom2,
        imFolderCustom3 = iml.imFolderAttributeID.imFolderCustom3,
        imFolderRootFolderID = iml.imFolderAttributeID.imFolderRootFolderID,
        imFolderRootFolderType = iml.imFolderAttributeID.imFolderRootFolderType,
        imFolderIsContentSearch = iml.imFolderAttributeID.imFolderIsContentSearch,
        imFolderIsFolderSearch = iml.imFolderAttributeID.imFolderIsFolderSearch,
        imFolderEmail = iml.imFolderAttributeID.imFolderEmail,
        imFolderHiddenOnDesktop = iml.imFolderAttributeID.imFolderHiddenOnDesktop,
        imFolderEditDate = iml.imFolderAttributeID.imFolderEditDate,
        imFolderReferenceType = iml.imFolderAttributeID.imFolderReferenceType
    }

    public enum imFoldersOp
    {
        imAddFoldersOp = iml.imFoldersOp.imAddFoldersOp,
        imRemoveFoldersOp = iml.imFoldersOp.imRemoveFoldersOp
    }

    public enum imSearchAttributeType
    {
        imSearchID = iml.imSearchAttributeType.imSearchID,
        imSearchFullName = iml.imSearchAttributeType.imSearchFullName,
        imSearchBoth = iml.imSearchAttributeType.imSearchBoth,
        imSearchExactMatch = iml.imSearchAttributeType.imSearchExactMatch
    }

    public enum imSecurityType
    {
        imPublic = iml.imSecurityType.imPublic,
        imView = iml.imSecurityType.imView,
        imPrivate = iml.imSecurityType.imPrivate
    }

    public enum imIntMode
    {
        imIntegrationModeMacro = iml.imIntMode.imIntegrationModeMacro,
        imIntegrationModeODMA = iml.imIntMode.imIntegrationModeODMA,
        imIntegrationModeNonIntegrated = iml.imIntMode.imIntegrationModeNonIntegrated
    }

    public enum imNOS
    {
        imOSNovell = iml.imNOS.imOSNovell,
        imOSVirtual = iml.imNOS.imOSVirtual,
        imOSNT = iml.imNOS.imOSNT,
        imOSNovellNDS = iml.imNOS.imOSNovellNDS,
        imOSExternal = iml.imNOS.imOSExternal,
        imOSNTADS = iml.imNOS.imOSNTADS,
        imOSNetscapeDS = iml.imNOS.imOSNetscapeDS
    }

    public enum imRoleAttributeID
    {
        imRoleUseAdmin = iml.imRoleAttributeID.imRoleUseAdmin,
        imRoleUseMonitorApp = iml.imRoleAttributeID.imRoleUseMonitorApp,
        imRoleAdminUseImportApp = iml.imRoleAttributeID.imRoleAdminUseImportApp,
        imRoleExternal = iml.imRoleAttributeID.imRoleExternal,
        imRoleDocumentCheckout = iml.imRoleAttributeID.imRoleDocumentCheckout,
        imRoleDocumentCreate = iml.imRoleAttributeID.imRoleDocumentCreate,
        imRoleDocumentDelete = iml.imRoleAttributeID.imRoleDocumentDelete,
        imRoleDocumentFullTextSearch = iml.imRoleAttributeID.imRoleDocumentFullTextSearch,
        imRoleDocumentReadOnly = iml.imRoleAttributeID.imRoleDocumentReadOnly,
        imRoleDocumentUnlockDocument = iml.imRoleAttributeID.imRoleDocumentUnlockDocument,
        imRoleDocumentViewPublicDocument = iml.imRoleAttributeID.imRoleDocumentViewPublicDocument,
        imRoleFolderCreatePublicFolder = iml.imRoleAttributeID.imRoleFolderCreatePublicFolder,
        imRoleFolderCreatePublicSearchFolder = iml.imRoleAttributeID.imRoleFolderCreatePublicSearchFolder,
        imWebRoleSearchWorkspaces = iml.imRoleAttributeID.imWebRoleSearchWorkspaces,
        imWebRoleAuthorWorkspaces = iml.imRoleAttributeID.imWebRoleAuthorWorkspaces,
        imWebRoleAuthorPublicWorkspaces = iml.imRoleAttributeID.imWebRoleAuthorPublicWorkspaces,
        imWebRoleCreateSystemWorkspaces = iml.imRoleAttributeID.imWebRoleCreateSystemWorkspaces,
        imRoleWorkspaceDeleteWorkspace = iml.imRoleAttributeID.imRoleWorkspaceDeleteWorkspace,
        imRoleAdminViewDocuments = iml.imRoleAttributeID.imRoleAdminViewDocuments
    }

    public enum imAccessRight
    {
        imRightNone = iml.imAccessRight.imRightNone,
        imRightRead = iml.imAccessRight.imRightRead,
        imRightReadWrite = iml.imAccessRight.imRightReadWrite,
        imRightAll = iml.imAccessRight.imRightAll
    }

    public enum imHistEvent
    {
        imHistoryLaunch = iml.imHistEvent.imHistoryLaunch,
        imHistoryView = iml.imHistEvent.imHistoryView,
        imHistoryCheckout = iml.imHistEvent.imHistoryCheckout,
        imHistoryCheckin = iml.imHistEvent.imHistoryCheckin,
        imHistoryProfileEdit = iml.imHistEvent.imHistoryProfileEdit,
        imHistoryClose = iml.imHistEvent.imHistoryClose,
        imHistoryNew = iml.imHistEvent.imHistoryNew,
        imHistoryVersionNew = iml.imHistEvent.imHistoryVersionNew,
        imHistorySecurityChange = iml.imHistEvent.imHistorySecurityChange,
        imHistoryCopy = iml.imHistEvent.imHistoryCopy,
        imHistoryPrint = iml.imHistEvent.imHistoryPrint,
        imHistoryMail = iml.imHistEvent.imHistoryMail,
        imHistoryEchoSync = iml.imHistEvent.imHistoryEchoSync,
        imHistoryDelete = iml.imHistEvent.imHistoryDelete,
        imHistoryPurge = iml.imHistEvent.imHistoryPurge,
        imHistoryArchive = iml.imHistEvent.imHistoryArchive,
        imHistoryRestore = iml.imHistEvent.imHistoryRestore,
        imHistoryRelease = iml.imHistEvent.imHistoryRelease,
        imHistoryExport = iml.imHistEvent.imHistoryExport,
        imHistoryModify = iml.imHistEvent.imHistoryModify,
        imHistoryEditTime = iml.imHistEvent.imHistoryEditTime,
        imHistoryNotLogged = iml.imHistEvent.imHistoryNotLogged,
        imHistoryFrozen = iml.imHistEvent.imHistoryFrozen,
        imHistoryMigrated = iml.imHistEvent.imHistoryMigrated,
        imHistoryUndeclared = iml.imHistEvent.imHistoryUndeclared,
        imHistoryReconciled = iml.imHistEvent.imHistoryReconciled,
        imHistoryRemoveFromFolder = iml.imHistEvent.imHistoryRemoveFromFolder,
        imHistoryDeleteFolder = iml.imHistEvent.imHistoryDeleteFolder,
        imHistoryWorkflowEvent = iml.imHistEvent.imHistoryWorkflowEvent,
        imHistoryWorkflowAttach = iml.imHistEvent.imHistoryWorkflowAttach,
        imHistoryWorkflowDetach = iml.imHistEvent.imHistoryWorkflowDetach,
        imHistoryShred = iml.imHistEvent.imHistoryShred
    }

    public enum imWorkspaceOperation
    {
        imCopyWorkspaceOp = iml.imWorkspaceOperation.imCopyWorkspaceOp,
        imUpdateWorkspaceOp = iml.imWorkspaceOperation.imUpdateWorkspaceOp,
        imLockWorkspaceOp = iml.imWorkspaceOperation.imLockWorkspaceOp,
        imUnlockWorkspaceOp = iml.imWorkspaceOperation.imUnlockWorkspaceOp,
        imArchiveWorkspaceOp = iml.imWorkspaceOperation.imArchiveWorkspaceOp,
        imRestoreWorkspaceOp = iml.imWorkspaceOperation.imRestoreWorkspaceOp,
        imSetSecurityWorkspaceOp = iml.imWorkspaceOperation.imSetSecurityWorkspaceOp,
        imDeleteWorkspaceOp = iml.imWorkspaceOperation.imDeleteWorkspaceOp,
        imChangeNameWorkspaceOp = iml.imWorkspaceOperation.imChangeNameWorkspaceOp
    }

    public enum imProfileErrorCode
    {
        imErrorFieldRequired = iml.imProfileErrorCode.imErrorFieldRequired,
        imErrorFieldDisabled = iml.imProfileErrorCode.imErrorFieldDisabled,
        imErrorItemInvalid = iml.imProfileErrorCode.imErrorItemInvalid,
        imFieldErrorRelation = iml.imProfileErrorCode.imFieldErrorRelation
    }

    public enum imWorkspaceSubtype
    {
        imWorkspaceWorkSubtype = iml.imWorkspaceSubtype.imWorkspaceWorkSubtype,
        imWorkspaceTemplateSubtype = iml.imWorkspaceSubtype.imWorkspaceTemplateSubtype,
        imWorkspaceStartSubtype = iml.imWorkspaceSubtype.imWorkspaceStartSubtype,
        imWorkspaceConnectorSubtype = iml.imWorkspaceSubtype.imWorkspaceConnectorSubtype,
        imWorkspaceAdminSubtype = iml.imWorkspaceSubtype.imWorkspaceAdminSubtype,
        imWorkspacePreferencesSubtype = iml.imWorkspaceSubtype.imWorkspacePreferencesSubtype,
        imWorkspaceUnknownSubtype = iml.imWorkspaceSubtype.imWorkspaceUnknownSubtype
    }

    public enum imPreferenceType
    {
        imPreferenceExplorer = iml.imPreferenceType.imPreferenceExplorer,
        imPreferenceWorklist = iml.imPreferenceType.imPreferenceWorklist,
        imPreferenceCheckedOutDocuments = iml.imPreferenceType.imPreferenceCheckedOutDocuments,
        imPreferenceSearchHistory = iml.imPreferenceType.imPreferenceSearchHistory,
        imPreferenceSubscriptions = iml.imPreferenceType.imPreferenceSubscriptions,
        imPreferenceFavorites = iml.imPreferenceType.imPreferenceFavorites,
        imPreferenceRecentWorkspaces = iml.imPreferenceType.imPreferenceRecentWorkspaces
    }

    public enum imControlType
    {
        imLabelWidget = iml.imControlType.imLabelWidget,
        imEditWidget = iml.imControlType.imEditWidget,
        imButtonWidget = iml.imControlType.imButtonWidget,
        imListWidget = iml.imControlType.imListWidget,
        imDateWidget = iml.imControlType.imDateWidget,
        imBorButtonWidget = iml.imControlType.imBorButtonWidget,
        imShadeWidget = iml.imControlType.imShadeWidget,
        imHDipWidget = iml.imControlType.imHDipWidget,
        imVDipWidget = iml.imControlType.imVDipWidget,
        imCheckWidget = iml.imControlType.imCheckWidget,
        imRadioWidget = iml.imControlType.imRadioWidget,
        imComboWidget = iml.imControlType.imComboWidget,
        imActiveLabel = iml.imControlType.imActiveLabel
    }

    public enum imFormType
    {
        imFormSearchDialog = iml.imFormType.imFormSearchDialog,
        imFormNewProfile = iml.imFormType.imFormNewProfile,
        imFormNewVersion = iml.imFormType.imFormNewVersion,
        imFormEditProfile = iml.imFormType.imFormEditProfile,
        imFormWorkspaceSearch = iml.imFormType.imFormWorkspaceSearch,
        imFormQuickSearch = iml.imFormType.imFormQuickSearch,
        imFormNewWorkspace = iml.imFormType.imFormNewWorkspace,
        imFormEditWorkspace = iml.imFormType.imFormEditWorkspace
    }

    public enum imFullTextSearchLocation
    {
        imFullTextAnywhere = iml.imFullTextSearchLocation.imFullTextAnywhere,
        imFullTextComment = iml.imFullTextSearchLocation.imFullTextComment,
        imFullTextDescription = iml.imFullTextSearchLocation.imFullTextDescription,
        imFullTextBody = iml.imFullTextSearchLocation.imFullTextBody,
        imFullTextCommentDescription = iml.imFullTextSearchLocation.imFullTextCommentDescription
    }

    public enum imSearchEmail
    {
        imSearchEmailOrDocuments = iml.imSearchEmail.imSearchEmailOrDocuments,
        imSearchEmailOnly = iml.imSearchEmail.imSearchEmailOnly,
        imSearchDocumentsOnly = iml.imSearchEmail.imSearchDocumentsOnly
    }

    public enum imEventAttributeID
    {
        imEventDatabase = iml.imEventAttributeID.imEventDatabase,
        imEventID = iml.imEventAttributeID.imEventID,
        imEventSubject = iml.imEventAttributeID.imEventSubject,
        imEventOrganizer = iml.imEventAttributeID.imEventOrganizer,
        imEventAssignee = iml.imEventAttributeID.imEventAssignee,
        imEventType = iml.imEventAttributeID.imEventType,
        imEventClass = iml.imEventAttributeID.imEventClass,
        imEventSubClass = iml.imEventAttributeID.imEventSubClass,
        imEventEditDate = iml.imEventAttributeID.imEventEditDate,
        imEventCreateDate = iml.imEventAttributeID.imEventCreateDate,
        imEventRetainDays = iml.imEventAttributeID.imEventRetainDays,
        imEventIndexable = iml.imEventAttributeID.imEventIndexable,
        imEventDefaultSecurity = iml.imEventAttributeID.imEventDefaultSecurity,
        imEventLastUser = iml.imEventAttributeID.imEventLastUser,
        imEventInUseBy = iml.imEventAttributeID.imEventInUseBy,
        imEventInUse = iml.imEventAttributeID.imEventInUse,
        imEventArchived = iml.imEventAttributeID.imEventArchived,
        imEventContacts = iml.imEventAttributeID.imEventContacts,
        imEventCategories = iml.imEventAttributeID.imEventCategories,
        imEventLocation = iml.imEventAttributeID.imEventLocation,
        imEventSoundFile = iml.imEventAttributeID.imEventSoundFile,
        imEventAttendee = iml.imEventAttributeID.imEventAttendee,
        imEventShowTimeAs = iml.imEventAttributeID.imEventShowTimeAs,
        imEventPriority = iml.imEventAttributeID.imEventPriority,
        imEventAllDayEvent = iml.imEventAttributeID.imEventAllDayEvent,
        imEventSynchTime = iml.imEventAttributeID.imEventSynchTime,
        imEventStartTime = iml.imEventAttributeID.imEventStartTime,
        imEventEndTime = iml.imEventAttributeID.imEventEndTime,
        imEventReminderTime = iml.imEventAttributeID.imEventReminderTime,
        imEventRecurring = iml.imEventAttributeID.imEventRecurring,
        imEventReminder = iml.imEventAttributeID.imEventReminder,
        imEventPlaySound = iml.imEventAttributeID.imEventPlaySound,
        imEventHasAttachments = iml.imEventAttributeID.imEventHasAttachments,
        imEventOrganizerDescription = iml.imEventAttributeID.imEventOrganizerDescription,
        imEventAssigneeDescription = iml.imEventAttributeID.imEventAssigneeDescription,
        imEventTypeDescription = iml.imEventAttributeID.imEventTypeDescription,
        imEventClassDescription = iml.imEventAttributeID.imEventClassDescription,
        imEventSubClassDescription = iml.imEventAttributeID.imEventSubClassDescription,
        imEventLastUserDescription = iml.imEventAttributeID.imEventLastUserDescription,
        imEventInUseByDescription = iml.imEventAttributeID.imEventInUseByDescription,
        imEventEditTime = iml.imEventAttributeID.imEventEditTime,
        imEventFullText = iml.imEventAttributeID.imEventFullText,
        imEventContainerID = iml.imEventAttributeID.imEventContainerID,
        imEventMarkedForArchive = iml.imEventAttributeID.imEventMarkedForArchive
    }

    public enum imTaskAttributeID
    {
        imTaskDatabase = iml.imTaskAttributeID.imTaskDatabase,
        imTaskID = iml.imTaskAttributeID.imTaskID,
        imTaskSubject = iml.imTaskAttributeID.imTaskSubject,
        imTaskAssignee = iml.imTaskAttributeID.imTaskAssignee,
        imTaskOwner = iml.imTaskAttributeID.imTaskOwner,
        imTaskType = iml.imTaskAttributeID.imTaskType,
        imTaskClass = iml.imTaskAttributeID.imTaskClass,
        imTaskSubClass = iml.imTaskAttributeID.imTaskSubClass,
        imTaskEditDate = iml.imTaskAttributeID.imTaskEditDate,
        imTaskCreateDate = iml.imTaskAttributeID.imTaskCreateDate,
        imTaskRetainDays = iml.imTaskAttributeID.imTaskRetainDays,
        imTaskSize = iml.imTaskAttributeID.imTaskSize,
        imTaskIndexable = iml.imTaskAttributeID.imTaskIndexable,
        imTaskDefaultSecurity = iml.imTaskAttributeID.imTaskDefaultSecurity,
        imTaskLastUser = iml.imTaskAttributeID.imTaskLastUser,
        imTaskInUseBy = iml.imTaskAttributeID.imTaskInUseBy,
        imTaskInUse = iml.imTaskAttributeID.imTaskInUse,
        imTaskArchived = iml.imTaskAttributeID.imTaskArchived,
        imTaskContacts = iml.imTaskAttributeID.imTaskContacts,
        imTaskCategories = iml.imTaskAttributeID.imTaskCategories,
        imTaskRecurringPattern = iml.imTaskAttributeID.imTaskRecurringPattern,
        imTaskSoundFile = iml.imTaskAttributeID.imTaskSoundFile,
        imTaskUserProperty1 = iml.imTaskAttributeID.imTaskUserProperty1,
        imTaskStatus = iml.imTaskAttributeID.imTaskStatus,
        imTaskPriority = iml.imTaskAttributeID.imTaskPriority,
        imTaskPercentageComplete = iml.imTaskAttributeID.imTaskPercentageComplete,
        imTaskTotalWork = iml.imTaskAttributeID.imTaskTotalWork,
        imTaskSynchTime = iml.imTaskAttributeID.imTaskSynchTime,
        imTaskStartDate = iml.imTaskAttributeID.imTaskStartDate,
        imTaskDateCompleted = iml.imTaskAttributeID.imTaskDateCompleted,
        imTaskDateDue = iml.imTaskAttributeID.imTaskDateDue,
        imTaskRecurring = iml.imTaskAttributeID.imTaskRecurring,
        imTaskReminder = iml.imTaskAttributeID.imTaskReminder,
        imTaskPlaySound = iml.imTaskAttributeID.imTaskPlaySound,
        imTaskHasAttachments = iml.imTaskAttributeID.imTaskHasAttachments,
        imTaskAssigneeDescription = iml.imTaskAttributeID.imTaskAssigneeDescription,
        imTaskOwnerDescription = iml.imTaskAttributeID.imTaskOwnerDescription,
        imTaskTypeDescription = iml.imTaskAttributeID.imTaskTypeDescription,
        imTaskClassDescription = iml.imTaskAttributeID.imTaskClassDescription,
        imTaskSubClassDescription = iml.imTaskAttributeID.imTaskSubClassDescription,
        imTaskLastUserDescription = iml.imTaskAttributeID.imTaskLastUserDescription,
        imTaskInUseByDescription = iml.imTaskAttributeID.imTaskInUseByDescription,
        imTaskEditTime = iml.imTaskAttributeID.imTaskEditTime,
        imTaskFullText = iml.imTaskAttributeID.imTaskFullText,
        imTaskContainerID = iml.imTaskAttributeID.imTaskContainerID,
        imTaskMarkedForArchive = iml.imTaskAttributeID.imTaskMarkedForArchive
    }

    public enum imMessageAttributeID
    {
        imMessageDatabase = iml.imMessageAttributeID.imMessageDatabase,
        imMessageID = iml.imMessageAttributeID.imMessageID,
        imMessageDescription = iml.imMessageAttributeID.imMessageDescription,
        imMessageAuthor = iml.imMessageAttributeID.imMessageAuthor,
        imMessageType = iml.imMessageAttributeID.imMessageType,
        imMessageClass = iml.imMessageAttributeID.imMessageClass,
        imMessageSubClass = iml.imMessageAttributeID.imMessageSubClass,
        imMessageEditDate = iml.imMessageAttributeID.imMessageEditDate,
        imMessageCreateDate = iml.imMessageAttributeID.imMessageCreateDate,
        imMessageRetainDays = iml.imMessageAttributeID.imMessageRetainDays,
        imMessageSize = iml.imMessageAttributeID.imMessageSize,
        imMessageIndexable = iml.imMessageAttributeID.imMessageIndexable,
        imMessageDefaultSecurity = iml.imMessageAttributeID.imMessageDefaultSecurity,
        imMessageLastUser = iml.imMessageAttributeID.imMessageLastUser,
        imMessageInUseBy = iml.imMessageAttributeID.imMessageInUseBy,
        imMessageInUse = iml.imMessageAttributeID.imMessageInUse,
        imMessageArchived = iml.imMessageAttributeID.imMessageArchived,
        imMessageIcon = iml.imMessageAttributeID.imMessageIcon,
        imMessageTarget = iml.imMessageAttributeID.imMessageTarget,
        imMessageEditTime = iml.imMessageAttributeID.imMessageEditTime,
        imMessageFullText = iml.imMessageAttributeID.imMessageFullText,
        imMessageContainerID = iml.imMessageAttributeID.imMessageContainerID,
        imMessageMarkedForArchive = iml.imMessageAttributeID.imMessageMarkedForArchive
    }

    public enum imDateRangeType
    {
        imAbsoluteDateRangeType = iml.imDateRangeType.imAbsoluteDateRangeType,
        imRelativeDateRangeType = iml.imDateRangeType.imRelativeDateRangeType
    }

    public enum imGranularity
    {
        eSecond = iml.imGranularity.eSecond,
        eMinute = iml.imGranularity.eMinute,
        eHour = iml.imGranularity.eHour,
        eDay = iml.imGranularity.eDay,
        eWeek = iml.imGranularity.eWeek,
        eMonth = iml.imGranularity.eMonth,
        eQuarter = iml.imGranularity.eQuarter,
        eYear = iml.imGranularity.eYear
    }

    public enum imCollaborationOperation
    {
        imCheckOutOp = iml.imCollaborationOperation.imCheckOutOp,
        imCheckInOp = iml.imCollaborationOperation.imCheckInOp,
        imCopyOp = iml.imCollaborationOperation.imCopyOp,
        imUpdateOp = iml.imCollaborationOperation.imUpdateOp,
        imLockOp = iml.imCollaborationOperation.imLockOp,
        imUnlockOp = iml.imCollaborationOperation.imUnlockOp,
        imArchiveOp = iml.imCollaborationOperation.imArchiveOp,
        imRestoreOp = iml.imCollaborationOperation.imRestoreOp,
        imSetSecurityOp = iml.imCollaborationOperation.imSetSecurityOp,
        imDeleteOp = iml.imCollaborationOperation.imDeleteOp
    }

    public enum imSearchEnabledDisabled
    {
        imSearchEnabledOrDisabled = iml.imSearchEnabledDisabled.imSearchEnabledOrDisabled,
        imSearchEnabledOnly = iml.imSearchEnabledDisabled.imSearchEnabledOnly,
        imSearchDisabledOnly = iml.imSearchEnabledDisabled.imSearchDisabledOnly
    }

    public enum imCheckinDisposition
    {
        imCheckinNewVersion = iml.imCheckinDisposition.imCheckinNewVersion,
        imCheckinNewDocument = iml.imCheckinDisposition.imCheckinNewDocument,
        imCheckinReplaceOriginal = iml.imCheckinDisposition.imCheckinReplaceOriginal,
        imCheckinReplaceDocumentOnly = iml.imCheckinDisposition.imCheckinReplaceDocumentOnly,
        imCheckinReplaceProfileOnly = iml.imCheckinDisposition.imCheckinReplaceProfileOnly
    }

    public enum imCheckinOptions
    {
        imDontKeepCheckedOut = iml.imCheckinOptions.imDontKeepCheckedOut,
        imKeepCheckedOut = iml.imCheckinOptions.imKeepCheckedOut
    }

    public enum imCheckOutOptions
    {
        imDontReplaceExistingFile = iml.imCheckOutOptions.imDontReplaceExistingFile,
        imReplaceExistingFile = iml.imCheckOutOptions.imReplaceExistingFile
    }

    public enum imGetCopyOptions
    {
        imNativeFormat = iml.imGetCopyOptions.imNativeFormat,
        imHTMLFormat = iml.imGetCopyOptions.imHTMLFormat
    }

    public enum imDocumentSubType
    {
        imSubTypeNone = iml.imDocumentSubType.imSubTypeNone,
        imSubTypePreferences = iml.imDocumentSubType.imSubTypePreferences,
        imSubTypeView = iml.imDocumentSubType.imSubTypeView,
        imSubTypeDocumentProfile = iml.imDocumentSubType.imSubTypeDocumentProfile,
        imSubTypeSearchProfile = iml.imDocumentSubType.imSubTypeSearchProfile,
        imSubTypeCompound = iml.imDocumentSubType.imSubTypeCompound
    }

    public enum imDocumentOperation
    {
        imCheckOutDocumentOp = iml.imDocumentOperation.imCheckOutDocumentOp,
        imCheckInDocumentOp = iml.imDocumentOperation.imCheckInDocumentOp,
        imCopyDocumentOp = iml.imDocumentOperation.imCopyDocumentOp,
        imUpdateDocumentOp = iml.imDocumentOperation.imUpdateDocumentOp,
        imLockDocumentOp = iml.imDocumentOperation.imLockDocumentOp,
        imUnlockDocumentOp = iml.imDocumentOperation.imUnlockDocumentOp,
        imArchiveDocumentOp = iml.imDocumentOperation.imArchiveDocumentOp,
        imRestoreDocumentOp = iml.imDocumentOperation.imRestoreDocumentOp,
        imSetSecurityDocumentOp = iml.imDocumentOperation.imSetSecurityDocumentOp,
        imDeleteDocumentOp = iml.imDocumentOperation.imDeleteDocumentOp,
        imRelateDocumentOp = iml.imDocumentOperation.imRelateDocumentOp,
        imSyncDocumentOp = iml.imDocumentOperation.imSyncDocumentOp,
        imFreezeDocumentOp = iml.imDocumentOperation.imFreezeDocumentOp,
        imCheckinReplaceDocumentOp = iml.imDocumentOperation.imCheckinReplaceDocumentOp,
        imUnfreezeDocumentOp = iml.imDocumentOperation.imUnfreezeDocumentOp,
        imMoveDocumentOp = iml.imDocumentOperation.imMoveDocumentOp
    }

    public enum imDatabaseOperation
    {
        imDatabaseCreateDocument = iml.imDatabaseOperation.imDatabaseCreateDocument,
        imDatabaseDeleteDocument = iml.imDatabaseOperation.imDatabaseDeleteDocument,
        imDatabaseSearchFullText = iml.imDatabaseOperation.imDatabaseSearchFullText,
        imDatabaseCreatePublicFolder = iml.imDatabaseOperation.imDatabaseCreatePublicFolder,
        imDatabaseCreatePublicSearchFolder = iml.imDatabaseOperation.imDatabaseCreatePublicSearchFolder,
        imDatabaseSearchWorkspaces = iml.imDatabaseOperation.imDatabaseSearchWorkspaces,
        imDatabaseAuthorWorkspaces = iml.imDatabaseOperation.imDatabaseAuthorWorkspaces,
        imDatabaseAuthorPublicWorkspaces = iml.imDatabaseOperation.imDatabaseAuthorPublicWorkspaces,
        imDatabaseCreateSystemWorkspace = iml.imDatabaseOperation.imDatabaseCreateSystemWorkspace,
        imDatabaseDeleteWorkspace = iml.imDatabaseOperation.imDatabaseDeleteWorkspace,
        imDatabaseCreateFlatspaceDocument = iml.imDatabaseOperation.imDatabaseCreateFlatspaceDocument
    }

    public enum imNOSType
    {
        imExternalNOS = iml.imNOSType.imExternalNOS,
        imInternalNOS = iml.imNOSType.imInternalNOS,
        imAllNOS = iml.imNOSType.imAllNOS
    }

    public enum imFolderOp
    {
        imModifyFolderOp = iml.imFolderOp.imModifyFolderOp,
        imSetSecurityFolderOp = iml.imFolderOp.imSetSecurityFolderOp,
        imRemoveThisFolderOp = iml.imFolderOp.imRemoveThisFolderOp,
        imChangeNameFolderOp = iml.imFolderOp.imChangeNameFolderOp,
        imModifyLayoutOp = iml.imFolderOp.imModifyLayoutOp
    }

    public enum imGetObjectBySIDResult
    {
        imFound = iml.imGetObjectBySIDResult.imFound,
        imNotFound = iml.imGetObjectBySIDResult.imNotFound,
        imDatabaseNotFound = iml.imGetObjectBySIDResult.imDatabaseNotFound,
        imArchivedDocument = iml.imGetObjectBySIDResult.imArchivedDocument,
        imArchivedFolder = iml.imGetObjectBySIDResult.imArchivedFolder
    }

    public enum imHasProfilesOp
    {
        imAddHasProfilesOp = iml.imHasProfilesOp.imAddHasProfilesOp,
        imRemoveHasProfilesOp = iml.imHasProfilesOp.imRemoveHasProfilesOp
    }

    public enum AttributeID
    {
        nrDatabase = iml.AttributeID.nrDatabase,
        nrDocNum = iml.AttributeID.nrDocNum,
        nrVersion = iml.AttributeID.nrVersion,
        nrDescription = iml.AttributeID.nrDescription,
        nrName = iml.AttributeID.nrName,
        nrAuthor = iml.AttributeID.nrAuthor,
        nrOperator = iml.AttributeID.nrOperator,
        nrType = iml.AttributeID.nrType,
        nrClass = iml.AttributeID.nrClass,
        nrSubClass = iml.AttributeID.nrSubClass,
        nrEditDate = iml.AttributeID.nrEditDate,
        nrCreateDate = iml.AttributeID.nrCreateDate,
        nrRetainDays = iml.AttributeID.nrRetainDays,
        nrSize = iml.AttributeID.nrSize,
        nrIndexable = iml.AttributeID.nrIndexable,
        nrIsRelated = iml.AttributeID.nrIsRelated,
        nrLocation = iml.AttributeID.nrLocation,
        nrDefaultSecurity = iml.AttributeID.nrDefaultSecurity,
        nrLastUser = iml.AttributeID.nrLastUser,
        nrInUseBy = iml.AttributeID.nrInUseBy,
        nrNetNode = iml.AttributeID.nrNetNode,
        nrInUse = iml.AttributeID.nrInUse,
        nrCheckedOut = iml.AttributeID.nrCheckedOut,
        nrArchived = iml.AttributeID.nrArchived,
        nrComment = iml.AttributeID.nrComment,
        nrCustom1 = iml.AttributeID.nrCustom1,
        nrCustom2 = iml.AttributeID.nrCustom2,
        nrCustom3 = iml.AttributeID.nrCustom3,
        nrCustom4 = iml.AttributeID.nrCustom4,
        nrCustom5 = iml.AttributeID.nrCustom5,
        nrCustom6 = iml.AttributeID.nrCustom6,
        nrCustom7 = iml.AttributeID.nrCustom7,
        nrCustom8 = iml.AttributeID.nrCustom8,
        nrCustom9 = iml.AttributeID.nrCustom9,
        nrCustom10 = iml.AttributeID.nrCustom10,
        nrCustom11 = iml.AttributeID.nrCustom11,
        nrCustom12 = iml.AttributeID.nrCustom12,
        nrCustom13 = iml.AttributeID.nrCustom13,
        nrCustom14 = iml.AttributeID.nrCustom14,
        nrCustom15 = iml.AttributeID.nrCustom15,
        nrCustom16 = iml.AttributeID.nrCustom16,
        nrCustom17 = iml.AttributeID.nrCustom17,
        nrCustom18 = iml.AttributeID.nrCustom18,
        nrCustom19 = iml.AttributeID.nrCustom19,
        nrCustom20 = iml.AttributeID.nrCustom20,
        nrCustom21 = iml.AttributeID.nrCustom21,
        nrCustom22 = iml.AttributeID.nrCustom22,
        nrCustom23 = iml.AttributeID.nrCustom23,
        nrCustom24 = iml.AttributeID.nrCustom24,
        nrCustom25 = iml.AttributeID.nrCustom25,
        nrCustom26 = iml.AttributeID.nrCustom26,
        nrCustom27 = iml.AttributeID.nrCustom27,
        nrCustom28 = iml.AttributeID.nrCustom28,
        nrCustom29 = iml.AttributeID.nrCustom29,
        nrCustom30 = iml.AttributeID.nrCustom30,
        nrCustom1Description = iml.AttributeID.nrCustom1Description,
        nrCustom2Description = iml.AttributeID.nrCustom2Description,
        nrCustom3Description = iml.AttributeID.nrCustom3Description,
        nrCustom4Description = iml.AttributeID.nrCustom4Description,
        nrCustom5Description = iml.AttributeID.nrCustom5Description,
        nrCustom6Description = iml.AttributeID.nrCustom6Description,
        nrCustom7Description = iml.AttributeID.nrCustom7Description,
        nrCustom8Description = iml.AttributeID.nrCustom8Description,
        nrCustom9Description = iml.AttributeID.nrCustom9Description,
        nrCustom10Description = iml.AttributeID.nrCustom10Description,
        nrCustom11Description = iml.AttributeID.nrCustom11Description,
        nrCustom12Description = iml.AttributeID.nrCustom12Description,
        nrCustom29Description = iml.AttributeID.nrCustom29Description,
        nrCustom30Description = iml.AttributeID.nrCustom30Description,
        nrAuthorDescription = iml.AttributeID.nrAuthorDescription,
        nrOperatorDescription = iml.AttributeID.nrOperatorDescription,
        nrTypeDescription = iml.AttributeID.nrTypeDescription,
        nrClassDescription = iml.AttributeID.nrClassDescription,
        nrSubClassDescription = iml.AttributeID.nrSubClassDescription,
        nrLastUserDescription = iml.AttributeID.nrLastUserDescription,
        nrInUseByDescription = iml.AttributeID.nrInUseByDescription,
        nrEditTime = iml.AttributeID.nrEditTime,
        nrExtension = iml.AttributeID.nrExtension,
        nrFullText = iml.AttributeID.nrFullText,
        nrSubType = iml.AttributeID.nrSubType,
        nrEditProfileTime = iml.AttributeID.nrEditProfileTime,
        nrContainerID = iml.AttributeID.nrContainerID,
        nrCustom31 = iml.AttributeID.nrCustom31,
        nrMarkedForArchive = iml.AttributeID.nrMarkedForArchive,
        nrEchoEnabled = iml.AttributeID.nrEchoEnabled,
        nrAccessTime = iml.AttributeID.nrAccessTime,
        nrMessageUniqueID = iml.AttributeID.nrMessageUniqueID
    }

    public enum DiscussionAttributeID
    {
        nrDiscussionDatabase = iml.DiscussionAttributeID.nrDiscussionDatabase,
        nrDiscussionID = iml.DiscussionAttributeID.nrDiscussionID,
        nrDiscussionSubject = iml.DiscussionAttributeID.nrDiscussionSubject,
        nrDiscussionAuthor = iml.DiscussionAttributeID.nrDiscussionAuthor,
        nrDiscussionType = iml.DiscussionAttributeID.nrDiscussionType,
        nrDiscussionClass = iml.DiscussionAttributeID.nrDiscussionClass,
        nrDiscussionSubClass = iml.DiscussionAttributeID.nrDiscussionSubClass,
        nrDiscussionEditDate = iml.DiscussionAttributeID.nrDiscussionEditDate,
        nrDiscussionCreateDate = iml.DiscussionAttributeID.nrDiscussionCreateDate,
        nrDiscussionRetainDays = iml.DiscussionAttributeID.nrDiscussionRetainDays,
        nrDiscussionSize = iml.DiscussionAttributeID.nrDiscussionSize,
        nrDiscussionIndexable = iml.DiscussionAttributeID.nrDiscussionIndexable,
        nrDiscussionDefaultSecurity = iml.DiscussionAttributeID.nrDiscussionDefaultSecurity,
        nrDiscussionLastUser = iml.DiscussionAttributeID.nrDiscussionLastUser,
        nrDiscussionInUseBy = iml.DiscussionAttributeID.nrDiscussionInUseBy,
        nrDiscussionInUse = iml.DiscussionAttributeID.nrDiscussionInUse,
        nrDiscussionArchived = iml.DiscussionAttributeID.nrDiscussionArchived,
        nrDiscussionHasAttachments = iml.DiscussionAttributeID.nrDiscussionHasAttachments,
        nrDiscussionEditTime = iml.DiscussionAttributeID.nrDiscussionEditTime,
        nrDiscussionFullText = iml.DiscussionAttributeID.nrDiscussionFullText,
        nrDiscussionContainerID = iml.DiscussionAttributeID.nrDiscussionContainerID,
        nrDiscussionMarkedForArchive = iml.DiscussionAttributeID.nrDiscussionMarkedForArchive
    }

    public enum EventAttributeID
    {
        nrEventDatabase = iml.EventAttributeID.nrEventDatabase,
        nrEventID = iml.EventAttributeID.nrEventID,
        nrEventSubject = iml.EventAttributeID.nrEventSubject,
        nrEventOrganizer = iml.EventAttributeID.nrEventOrganizer,
        nrEventAssignee = iml.EventAttributeID.nrEventAssignee,
        nrEventType = iml.EventAttributeID.nrEventType,
        nrEventClass = iml.EventAttributeID.nrEventClass,
        nrEventSubClass = iml.EventAttributeID.nrEventSubClass,
        nrEventEditDate = iml.EventAttributeID.nrEventEditDate,
        nrEventCreateDate = iml.EventAttributeID.nrEventCreateDate,
        nrEventRetainDays = iml.EventAttributeID.nrEventRetainDays,
        nrEventIndexable = iml.EventAttributeID.nrEventIndexable,
        nrEventDefaultSecurity = iml.EventAttributeID.nrEventDefaultSecurity,
        nrEventLastUser = iml.EventAttributeID.nrEventLastUser,
        nrEventInUseBy = iml.EventAttributeID.nrEventInUseBy,
        nrEventInUse = iml.EventAttributeID.nrEventInUse,
        nrEventArchived = iml.EventAttributeID.nrEventArchived,
        nrEventContacts = iml.EventAttributeID.nrEventContacts,
        nrEventCategories = iml.EventAttributeID.nrEventCategories,
        nrEventLocation = iml.EventAttributeID.nrEventLocation,
        nrEventSoundFile = iml.EventAttributeID.nrEventSoundFile,
        nrEventAttendee = iml.EventAttributeID.nrEventAttendee,
        nrEventShowTimeAs = iml.EventAttributeID.nrEventShowTimeAs,
        nrEventPriority = iml.EventAttributeID.nrEventPriority,
        nrEventAllDayEvent = iml.EventAttributeID.nrEventAllDayEvent,
        nrEventSynchTime = iml.EventAttributeID.nrEventSynchTime,
        nrEventStartTime = iml.EventAttributeID.nrEventStartTime,
        nrEventEndTime = iml.EventAttributeID.nrEventEndTime,
        nrEventReminderTime = iml.EventAttributeID.nrEventReminderTime,
        nrEventRecurring = iml.EventAttributeID.nrEventRecurring,
        nrEventReminder = iml.EventAttributeID.nrEventReminder,
        nrEventPlaySound = iml.EventAttributeID.nrEventPlaySound,
        nrEventHasAttachments = iml.EventAttributeID.nrEventHasAttachments,
        nrEventOrganizerDescription = iml.EventAttributeID.nrEventOrganizerDescription,
        nrEventAssigneeDescription = iml.EventAttributeID.nrEventAssigneeDescription,
        nrEventTypeDescription = iml.EventAttributeID.nrEventTypeDescription,
        nrEventClassDescription = iml.EventAttributeID.nrEventClassDescription,
        nrEventSubClassDescription = iml.EventAttributeID.nrEventSubClassDescription,
        nrEventLastUserDescription = iml.EventAttributeID.nrEventLastUserDescription,
        nrEventInUseByDescription = iml.EventAttributeID.nrEventInUseByDescription,
        nrEventEditTime = iml.EventAttributeID.nrEventEditTime,
        nrEventFullText = iml.EventAttributeID.nrEventFullText,
        nrEventContainerID = iml.EventAttributeID.nrEventContainerID,
        nrEventMarkedForArchive = iml.EventAttributeID.nrEventMarkedForArchive
    }

    public enum LinkAttributeID
    {
        nrLinkDatabase = iml.LinkAttributeID.nrLinkDatabase,
        nrLinkID = iml.LinkAttributeID.nrLinkID,
        nrLinkDescription = iml.LinkAttributeID.nrLinkDescription,
        nrLinkOwner = iml.LinkAttributeID.nrLinkOwner,
        nrLinkType = iml.LinkAttributeID.nrLinkType,
        nrLinkClass = iml.LinkAttributeID.nrLinkClass,
        nrLinkSubClass = iml.LinkAttributeID.nrLinkSubClass,
        nrLinkEditDate = iml.LinkAttributeID.nrLinkEditDate,
        nrLinkCreateDate = iml.LinkAttributeID.nrLinkCreateDate,
        nrLinkRetainDays = iml.LinkAttributeID.nrLinkRetainDays,
        nrLinkSize = iml.LinkAttributeID.nrLinkSize,
        nrLinkIndexable = iml.LinkAttributeID.nrLinkIndexable,
        nrLinkDefaultSecurity = iml.LinkAttributeID.nrLinkDefaultSecurity,
        nrLinkLastUser = iml.LinkAttributeID.nrLinkLastUser,
        nrLinkInUseBy = iml.LinkAttributeID.nrLinkInUseBy,
        nrLinkInUse = iml.LinkAttributeID.nrLinkInUse,
        nrLinkArchived = iml.LinkAttributeID.nrLinkArchived,
        nrLinkIcon = iml.LinkAttributeID.nrLinkIcon,
        nrLinkTarget = iml.LinkAttributeID.nrLinkTarget,
        nrLinkEditTime = iml.LinkAttributeID.nrLinkEditTime,
        nrLinkFullText = iml.LinkAttributeID.nrLinkFullText,
        nrLinkContainerID = iml.LinkAttributeID.nrLinkContainerID,
        nrLinkMarkedForArchive = iml.LinkAttributeID.nrLinkMarkedForArchive
    }

    public enum TaskAttributeID
    {
        nrTaskDatabase = iml.TaskAttributeID.nrTaskDatabase,
        nrTaskID = iml.TaskAttributeID.nrTaskID,
        nrTaskSubject = iml.TaskAttributeID.nrTaskSubject,
        nrTaskAssignee = iml.TaskAttributeID.nrTaskAssignee,
        nrTaskOwner = iml.TaskAttributeID.nrTaskOwner,
        nrTaskType = iml.TaskAttributeID.nrTaskType,
        nrTaskClass = iml.TaskAttributeID.nrTaskClass,
        nrTaskSubClass = iml.TaskAttributeID.nrTaskSubClass,
        nrTaskEditDate = iml.TaskAttributeID.nrTaskEditDate,
        nrTaskCreateDate = iml.TaskAttributeID.nrTaskCreateDate,
        nrTaskRetainDays = iml.TaskAttributeID.nrTaskRetainDays,
        nrTaskSize = iml.TaskAttributeID.nrTaskSize,
        nrTaskIndexable = iml.TaskAttributeID.nrTaskIndexable,
        nrTaskDefaultSecurity = iml.TaskAttributeID.nrTaskDefaultSecurity,
        nrTaskLastUser = iml.TaskAttributeID.nrTaskLastUser,
        nrTaskInUseBy = iml.TaskAttributeID.nrTaskInUseBy,
        nrTaskInUse = iml.TaskAttributeID.nrTaskInUse,
        nrTaskArchived = iml.TaskAttributeID.nrTaskArchived,
        nrTaskContacts = iml.TaskAttributeID.nrTaskContacts,
        nrTaskCategories = iml.TaskAttributeID.nrTaskCategories,
        nrTaskRecurringPattern = iml.TaskAttributeID.nrTaskRecurringPattern,
        nrTaskSoundFile = iml.TaskAttributeID.nrTaskSoundFile,
        nrTaskUserProperty1 = iml.TaskAttributeID.nrTaskUserProperty1,
        nrTaskStatus = iml.TaskAttributeID.nrTaskStatus,
        nrTaskPriority = iml.TaskAttributeID.nrTaskPriority,
        nrTaskPercentageComplete = iml.TaskAttributeID.nrTaskPercentageComplete,
        nrTaskTotalWork = iml.TaskAttributeID.nrTaskTotalWork,
        nrTaskSynchTime = iml.TaskAttributeID.nrTaskSynchTime,
        nrTaskStartDate = iml.TaskAttributeID.nrTaskStartDate,
        nrTaskDateCompleted = iml.TaskAttributeID.nrTaskDateCompleted,
        nrTaskDateDue = iml.TaskAttributeID.nrTaskDateDue,
        nrTaskRecurring = iml.TaskAttributeID.nrTaskRecurring,
        nrTaskReminder = iml.TaskAttributeID.nrTaskReminder,
        nrTaskPlaySound = iml.TaskAttributeID.nrTaskPlaySound,
        nrTaskHasAttachments = iml.TaskAttributeID.nrTaskHasAttachments,
        nrTaskAssigneeDescription = iml.TaskAttributeID.nrTaskAssigneeDescription,
        nrTaskOwnerDescription = iml.TaskAttributeID.nrTaskOwnerDescription,
        nrTaskTypeDescription = iml.TaskAttributeID.nrTaskTypeDescription,
        nrTaskClassDescription = iml.TaskAttributeID.nrTaskClassDescription,
        nrTaskSubClassDescription = iml.TaskAttributeID.nrTaskSubClassDescription,
        nrTaskLastUserDescription = iml.TaskAttributeID.nrTaskLastUserDescription,
        nrTaskInUseByDescription = iml.TaskAttributeID.nrTaskInUseByDescription,
        nrTaskEditTime = iml.TaskAttributeID.nrTaskEditTime,
        nrTaskFullText = iml.TaskAttributeID.nrTaskFullText,
        nrTaskContainerID = iml.TaskAttributeID.nrTaskContainerID,
        nrTaskMarkedForArchive = iml.TaskAttributeID.nrTaskMarkedForArchive
    }

    public enum IssueAttributeID
    {
        nrIssueDatabase = iml.IssueAttributeID.nrIssueDatabase,
        nrIssueID = iml.IssueAttributeID.nrIssueID,
        nrIssueSubject = iml.IssueAttributeID.nrIssueSubject,
        nrIssueAssignee = iml.IssueAttributeID.nrIssueAssignee,
        nrIssueOwner = iml.IssueAttributeID.nrIssueOwner,
        nrIssueType = iml.IssueAttributeID.nrIssueType,
        nrIssueClass = iml.IssueAttributeID.nrIssueClass,
        nrIssueSubClass = iml.IssueAttributeID.nrIssueSubClass,
        nrIssueEditDate = iml.IssueAttributeID.nrIssueEditDate,
        nrIssueCreateDate = iml.IssueAttributeID.nrIssueCreateDate,
        nrIssueRetainDays = iml.IssueAttributeID.nrIssueRetainDays,
        nrIssueSize = iml.IssueAttributeID.nrIssueSize,
        nrIssueIndexable = iml.IssueAttributeID.nrIssueIndexable,
        nrIssueDefaultSecurity = iml.IssueAttributeID.nrIssueDefaultSecurity,
        nrIssueLastUser = iml.IssueAttributeID.nrIssueLastUser,
        nrIssueInUseBy = iml.IssueAttributeID.nrIssueInUseBy,
        nrIssueInUse = iml.IssueAttributeID.nrIssueInUse,
        nrIssueArchived = iml.IssueAttributeID.nrIssueArchived,
        nrIssueContacts = iml.IssueAttributeID.nrIssueContacts,
        nrIssueCategories = iml.IssueAttributeID.nrIssueCategories,
        nrIssueRecurringPattern = iml.IssueAttributeID.nrIssueRecurringPattern,
        nrIssueSoundFile = iml.IssueAttributeID.nrIssueSoundFile,
        nrIssueUserProperty1 = iml.IssueAttributeID.nrIssueUserProperty1,
        nrIssueStatus = iml.IssueAttributeID.nrIssueStatus,
        nrIssuePriority = iml.IssueAttributeID.nrIssuePriority,
        nrIssuePercentageComplete = iml.IssueAttributeID.nrIssuePercentageComplete,
        nrIssueTotalWork = iml.IssueAttributeID.nrIssueTotalWork,
        nrIssueSynchTime = iml.IssueAttributeID.nrIssueSynchTime,
        nrIssueStartDate = iml.IssueAttributeID.nrIssueStartDate,
        nrIssueDateCompleted = iml.IssueAttributeID.nrIssueDateCompleted,
        nrIssueDateDue = iml.IssueAttributeID.nrIssueDateDue,
        nrIssueRecurring = iml.IssueAttributeID.nrIssueRecurring,
        nrIssueReminder = iml.IssueAttributeID.nrIssueReminder,
        nrIssuePlaySound = iml.IssueAttributeID.nrIssuePlaySound,
        nrIssueHasAttachments = iml.IssueAttributeID.nrIssueHasAttachments,
        nrIssueAssigneeDescription = iml.IssueAttributeID.nrIssueAssigneeDescription,
        nrIssueOwnerDescription = iml.IssueAttributeID.nrIssueOwnerDescription,
        nrIssueTypeDescription = iml.IssueAttributeID.nrIssueTypeDescription,
        nrIssueClassDescription = iml.IssueAttributeID.nrIssueClassDescription,
        nrIssueSubClassDescription = iml.IssueAttributeID.nrIssueSubClassDescription,
        nrIssueLastUserDescription = iml.IssueAttributeID.nrIssueLastUserDescription,
        nrIssueInUseByDescription = iml.IssueAttributeID.nrIssueInUseByDescription,
        nrIssueEditTime = iml.IssueAttributeID.nrIssueEditTime,
        nrIssueFullText = iml.IssueAttributeID.nrIssueFullText,
        nrIssueContainerID = iml.IssueAttributeID.nrIssueContainerID,
        nrIssueMarkedForArchive = iml.IssueAttributeID.nrIssueMarkedForArchive
    }

    public enum UserAttributeID
    {
        nrUserName = iml.UserAttributeID.nrUserName,
        nrUserFullName = iml.UserAttributeID.nrUserFullName,
        nrUserLocation = iml.UserAttributeID.nrUserLocation,
        nrUserPhone = iml.UserAttributeID.nrUserPhone,
        nrUserExtension = iml.UserAttributeID.nrUserExtension,
        nrUserLoginEnabled = iml.UserAttributeID.nrUserLoginEnabled,
        nrUserFax = iml.UserAttributeID.nrUserFax,
        nrUserComments = iml.UserAttributeID.nrUserComments,
        nrUserEmail = iml.UserAttributeID.nrUserEmail,
        nrUserPreferredDatabase = iml.UserAttributeID.nrUserPreferredDatabase,
        nrUserDomainName = iml.UserAttributeID.nrUserDomainName,
        nrUserNOS = iml.UserAttributeID.nrUserNOS,
        nrUserEmail2 = iml.UserAttributeID.nrUserEmail2,
        nrUserPager = iml.UserAttributeID.nrUserPager,
        nrUserMobile = iml.UserAttributeID.nrUserMobile,
        nrUserOther = iml.UserAttributeID.nrUserOther,
        nrUserCustom1 = iml.UserAttributeID.nrUserCustom1,
        nrUserCustom2 = iml.UserAttributeID.nrUserCustom2,
        nrUserCustom3 = iml.UserAttributeID.nrUserCustom3,
        nrUserEmail3 = iml.UserAttributeID.nrUserEmail3,
        nrUserEmail4 = iml.UserAttributeID.nrUserEmail4,
        nrUserEmail5 = iml.UserAttributeID.nrUserEmail5
    }

    public enum SearchAttributeType
    {
        nrSearchID = iml.SearchAttributeType.nrSearchID,
        nrSearchFullName = iml.SearchAttributeType.nrSearchFullName,
        nrSearchBoth = iml.SearchAttributeType.nrSearchBoth,
        nrSearchExactMatch = iml.SearchAttributeType.nrSearchExactMatch
    }

    public enum SecurityType
    {
        nrInherit = iml.SecurityType.nrInherit,
        nrPublic = iml.SecurityType.nrPublic,
        nrView = iml.SecurityType.nrView,
        nrPrivate = iml.SecurityType.nrPrivate
    }

    public enum IntMode
    {
        nrIntegrationModeMacro = iml.IntMode.nrIntegrationModeMacro,
        nrIntegrationModeODMA = iml.IntMode.nrIntegrationModeODMA,
        nrIntegrationModeNonIntegrated = iml.IntMode.nrIntegrationModeNonIntegrated
    }

    public enum RoleAttributeID
    {
        nrRoleUseAdmin = iml.RoleAttributeID.nrRoleUseAdmin,
        nrRoleUseMonitorApp = iml.RoleAttributeID.nrRoleUseMonitorApp,
        nrRoleAdminUseImportApp = iml.RoleAttributeID.nrRoleAdminUseImportApp,
        nrRoleExternal = iml.RoleAttributeID.nrRoleExternal,
        nrRoleDocumentCheckout = iml.RoleAttributeID.nrRoleDocumentCheckout,
        nrRoleDocumentCreate = iml.RoleAttributeID.nrRoleDocumentCreate,
        nrRoleDocumentDelete = iml.RoleAttributeID.nrRoleDocumentDelete,
        nrRoleDocumentEditPreviousVersion = iml.RoleAttributeID.nrRoleDocumentEditPreviousVersion,
        nrRoleDocumentFullTextSearch = iml.RoleAttributeID.nrRoleDocumentFullTextSearch,
        nrRoleDocumentReadOnly = iml.RoleAttributeID.nrRoleDocumentReadOnly,
        nrRoleDocumentRelease = iml.RoleAttributeID.nrRoleDocumentRelease,
        nrRoleDocumentViewPublicDocument = iml.RoleAttributeID.nrRoleDocumentViewPublicDocument,
        nrRoleFolderCreatePublicFolder = iml.RoleAttributeID.nrRoleFolderCreatePublicFolder,
        nrRoleFolderCreatePublicSearchFolder = iml.RoleAttributeID.nrRoleFolderCreatePublicSearchFolder,
        nrRoleFolderDeletePublicFolder = iml.RoleAttributeID.nrRoleFolderDeletePublicFolder,
        nrRoleFolderDeletePublicSearchFolder = iml.RoleAttributeID.nrRoleFolderDeletePublicSearchFolder,
        nrRoleFolderViewPublicFolder = iml.RoleAttributeID.nrRoleFolderViewPublicFolder,
        nrRoleFolderViewPublicSearchFolder = iml.RoleAttributeID.nrRoleFolderViewPublicSearchFolder,
        nrWebRoleBrowsePages = iml.RoleAttributeID.nrWebRoleBrowsePages,
        nrWebRoleSearchPages = iml.RoleAttributeID.nrWebRoleSearchPages,
        nrWebRoleAuthorPages = iml.RoleAttributeID.nrWebRoleAuthorPages,
        nrWebRoleSharePages = iml.RoleAttributeID.nrWebRoleSharePages,
        nrWebRoleCustomizePersonalViews = iml.RoleAttributeID.nrWebRoleCustomizePersonalViews,
        nrWebRoleCustomizePublicViews = iml.RoleAttributeID.nrWebRoleCustomizePublicViews,
        nrWebRoleCreateSystemPages = iml.RoleAttributeID.nrWebRoleCreateSystemPages,

        nrRoleSecurityAllowExternalUsersInDefaultDocumentCalculation =
            iml.RoleAttributeID.nrRoleSecurityAllowExternalUsersInDefaultDocumentCalculation,

        nrRoleSecurityAllowExternalUsersInDefaultFolderCalculation =
            iml.RoleAttributeID.nrRoleSecurityAllowExternalUsersInDefaultFolderCalculation
    }

    public enum AccessRight
    {
        nrRightNone = iml.AccessRight.nrRightNone,
        nrRightRead = iml.AccessRight.nrRightRead,
        nrRightReadWrite = iml.AccessRight.nrRightReadWrite,
        nrRightAll = iml.AccessRight.nrRightAll
    }

    public enum HistEvent
    {
        nrHistoryLaunch = iml.HistEvent.nrHistoryLaunch,
        nrHistoryView = iml.HistEvent.nrHistoryView,
        nrHistoryCheckout = iml.HistEvent.nrHistoryCheckout,
        nrHistoryCheckin = iml.HistEvent.nrHistoryCheckin,
        nrHistoryProfileEdit = iml.HistEvent.nrHistoryProfileEdit,
        nrHistoryClose = iml.HistEvent.nrHistoryClose,
        nrHistoryNew = iml.HistEvent.nrHistoryNew,
        nrHistoryVersionNew = iml.HistEvent.nrHistoryVersionNew,
        nrHistorySecurityChange = iml.HistEvent.nrHistorySecurityChange,
        nrHistoryCopy = iml.HistEvent.nrHistoryCopy,
        nrHistoryPrint = iml.HistEvent.nrHistoryPrint,
        nrHistoryMail = iml.HistEvent.nrHistoryMail,
        nrHistoryEchoSync = iml.HistEvent.nrHistoryEchoSync,
        nrHistoryDelete = iml.HistEvent.nrHistoryDelete,
        nrHistoryPurge = iml.HistEvent.nrHistoryPurge,
        nrHistoryArchive = iml.HistEvent.nrHistoryArchive,
        nrHistoryRestore = iml.HistEvent.nrHistoryRestore,
        nrHistoryRelease = iml.HistEvent.nrHistoryRelease,
        nrHistoryExport = iml.HistEvent.nrHistoryExport,
        nrHistoryModify = iml.HistEvent.nrHistoryModify,
        nrHistoryEditTime = iml.HistEvent.nrHistoryEditTime,
        nrHistoryNotLogged = iml.HistEvent.nrHistoryNotLogged
    }

    public enum CheckinDisposition
    {
        nrNewVersion = iml.CheckinDisposition.nrNewVersion,
        nrNewDocument = iml.CheckinDisposition.nrNewDocument,
        nrReplaceOriginal = iml.CheckinDisposition.nrReplaceOriginal,
        nrReplaceDocumentOnly = iml.CheckinDisposition.nrReplaceDocumentOnly,
        nrReplaceProfileOnly = iml.CheckinDisposition.nrReplaceProfileOnly
    }

    public enum CheckinOptions
    {
        nrDontKeepCheckedOut = iml.CheckinOptions.nrDontKeepCheckedOut,
        nrKeepCheckedOut = iml.CheckinOptions.nrKeepCheckedOut
    }

    public enum CheckOutOptions
    {
        nrDontReplaceExistingFile = iml.CheckOutOptions.nrDontReplaceExistingFile,
        nrReplaceExistingFile = iml.CheckOutOptions.nrReplaceExistingFile
    }

    public enum GetCopyOptions
    {
        nrNativeFormat = iml.GetCopyOptions.nrNativeFormat,
        nrHTMLFormat = iml.GetCopyOptions.nrHTMLFormat
    }

    public enum DocumentSubType
    {
        nrTypeNone = iml.DocumentSubType.nrTypeNone,
        nrTypePreferences = iml.DocumentSubType.nrTypePreferences,
        nrTypeView = iml.DocumentSubType.nrTypeView,
        nrTypeDocumentProfile = iml.DocumentSubType.nrTypeDocumentProfile,
        nrTypeSearchProfile = iml.DocumentSubType.nrTypeSearchProfile,
        nrTypeCompound = iml.DocumentSubType.nrTypeCompound
    }

    public enum DocumentOperation
    {
        nrCheckOutDocumentOp = iml.DocumentOperation.nrCheckOutDocumentOp,
        nrCheckInDocumentOp = iml.DocumentOperation.nrCheckInDocumentOp,
        nrCopyDocumentOp = iml.DocumentOperation.nrCopyDocumentOp,
        nrUpdateDocumentOp = iml.DocumentOperation.nrUpdateDocumentOp,
        nrLockDocumentOp = iml.DocumentOperation.nrLockDocumentOp,
        nrUnlockDocumentOp = iml.DocumentOperation.nrUnlockDocumentOp,
        nrArchiveDocumentOp = iml.DocumentOperation.nrArchiveDocumentOp,
        nrRestoreDocumentOp = iml.DocumentOperation.nrRestoreDocumentOp,
        nrSetSecurityDocumentOp = iml.DocumentOperation.nrSetSecurityDocumentOp,
        nrDeleteDocumentOp = iml.DocumentOperation.nrDeleteDocumentOp,
        nrRelateDocumentOp = iml.DocumentOperation.nrRelateDocumentOp,
        nrSyncDocumentOp = iml.DocumentOperation.nrSyncDocumentOp
    }

    public enum FolderOperation
    {
        nrModifyFolderOp = iml.FolderOperation.nrModifyFolderOp,
        nrSetSecurityFolderOp = iml.FolderOperation.nrSetSecurityFolderOp,
        nrAddDocumentFolderOp = iml.FolderOperation.nrAddDocumentFolderOp,
        nrCreateSubFolderFolderOp = iml.FolderOperation.nrCreateSubFolderFolderOp,
        nrRemoveDocumentFolderOp = iml.FolderOperation.nrRemoveDocumentFolderOp,
        nrRemoveSubFolderFolderOp = iml.FolderOperation.nrRemoveSubFolderFolderOp,
        nrRemoveThisFolderOp = iml.FolderOperation.nrRemoveThisFolderOp,
        nrChangeNameFolderOp = iml.FolderOperation.nrChangeNameFolderOp
    }

    public enum CollaborationOperation
    {
        nrCheckOutOp = iml.CollaborationOperation.nrCheckOutOp,
        nrCheckInOp = iml.CollaborationOperation.nrCheckInOp,
        nrCopyOp = iml.CollaborationOperation.nrCopyOp,
        nrUpdateOp = iml.CollaborationOperation.nrUpdateOp,
        nrLockOp = iml.CollaborationOperation.nrLockOp,
        nrUnlockOp = iml.CollaborationOperation.nrUnlockOp,
        nrArchiveOp = iml.CollaborationOperation.nrArchiveOp,
        nrRestoreOp = iml.CollaborationOperation.nrRestoreOp,
        nrSetSecurityOp = iml.CollaborationOperation.nrSetSecurityOp,
        nrDeleteOp = iml.CollaborationOperation.nrDeleteOp
    }

    public enum PageUpdateOptions
    {
        nrPageUpdateAll = iml.PageUpdateOptions.nrPageUpdateAll,
        nrPageUpdateProfile = iml.PageUpdateOptions.nrPageUpdateProfile,
        nrPageUpdateDocument = iml.PageUpdateOptions.nrPageUpdateDocument
    }

    public enum PageOperation
    {
        nrCopyPageOp = iml.PageOperation.nrCopyPageOp,
        nrUpdatePageOp = iml.PageOperation.nrUpdatePageOp,
        nrLockPageOp = iml.PageOperation.nrLockPageOp,
        nrUnlockPageOp = iml.PageOperation.nrUnlockPageOp,
        nrArchivePageOp = iml.PageOperation.nrArchivePageOp,
        nrRestorePageOp = iml.PageOperation.nrRestorePageOp,
        nrSetSecurityPageOp = iml.PageOperation.nrSetSecurityPageOp,
        nrDeletePageOp = iml.PageOperation.nrDeletePageOp,
        nrChangeNamePageOp = iml.PageOperation.nrChangeNamePageOp
    }

    public enum SessionOperation
    {
        nrSessionFullTextSearch = iml.SessionOperation.nrSessionFullTextSearch,
        nrSessionPublicDocumentsSearch = iml.SessionOperation.nrSessionPublicDocumentsSearch
    }

    public enum ControlType
    {
        nrLabelWidget = iml.ControlType.nrLabelWidget,
        nrEditWidget = iml.ControlType.nrEditWidget,
        nrButtonWidget = iml.ControlType.nrButtonWidget,
        nrListWidget = iml.ControlType.nrListWidget,
        nrDateWidget = iml.ControlType.nrDateWidget,
        nrBorButtonWidget = iml.ControlType.nrBorButtonWidget,
        nrShadeWidget = iml.ControlType.nrShadeWidget,
        nrHDipWidget = iml.ControlType.nrHDipWidget,
        nrVDipWidget = iml.ControlType.nrVDipWidget,
        nrCheckWidget = iml.ControlType.nrCheckWidget,
        nrRadioWidget = iml.ControlType.nrRadioWidget,
        nrComboWidget = iml.ControlType.nrComboWidget,
        nrActiveLabel = iml.ControlType.nrActiveLabel
    }

    public enum FormType
    {
        nrFormSearchDialog = iml.FormType.nrFormSearchDialog,
        nrFormNewProfile = iml.FormType.nrFormNewProfile,
        nrFormNewVersion = iml.FormType.nrFormNewVersion,
        nrFormEditProfile = iml.FormType.nrFormEditProfile
    }

    public enum AttributeType
    {
        nrEmpty = iml.AttributeType.nrEmpty,
        nrNull = iml.AttributeType.nrNull,
        nrInteger = iml.AttributeType.nrInteger,
        nrLong = iml.AttributeType.nrLong,
        nrSingle = iml.AttributeType.nrSingle,
        nrDouble = iml.AttributeType.nrDouble,
        nrCurrency = iml.AttributeType.nrCurrency,
        nrDate = iml.AttributeType.nrDate,
        nrString = iml.AttributeType.nrString,
        nrObject = iml.AttributeType.nrObject,
        nrError = iml.AttributeType.nrError,
        nrBoolean = iml.AttributeType.nrBoolean,
        nrVariant = iml.AttributeType.nrVariant,
        nrDataObject = iml.AttributeType.nrDataObject,
        nrDecimal = iml.AttributeType.nrDecimal,
        nrByte = iml.AttributeType.nrByte,
        nrArray = iml.AttributeType.nrArray
    }

    public enum DatabaseOperation
    {
        nrDatabaseCreateDocument = iml.DatabaseOperation.nrDatabaseCreateDocument,
        nrDatabaseDeleteDocument = iml.DatabaseOperation.nrDatabaseDeleteDocument,
        nrDatabaseSearchFullText = iml.DatabaseOperation.nrDatabaseSearchFullText,
        nrDatabaseViewPublicDocument = iml.DatabaseOperation.nrDatabaseViewPublicDocument,
        nrDatabaseCreatePublicFolder = iml.DatabaseOperation.nrDatabaseCreatePublicFolder,
        nrDatabaseCreatePublicSearchFolder = iml.DatabaseOperation.nrDatabaseCreatePublicSearchFolder,
        nrDatabaseDeletePublicFolder = iml.DatabaseOperation.nrDatabaseDeletePublicFolder,
        nrDatabaseDeletePublicSearchFolder = iml.DatabaseOperation.nrDatabaseDeletePublicSearchFolder,
        nrDatabaseViewPublicFolder = iml.DatabaseOperation.nrDatabaseViewPublicFolder,
        nrDatabaseViewPublicSearchFolder = iml.DatabaseOperation.nrDatabaseViewPublicSearchFolder,
        nrDatabaseBrowsePages = iml.DatabaseOperation.nrDatabaseBrowsePages,
        nrDatabaseSearchPages = iml.DatabaseOperation.nrDatabaseSearchPages,
        nrDatabaseAuthorPages = iml.DatabaseOperation.nrDatabaseAuthorPages,
        nrDatabaseSharePages = iml.DatabaseOperation.nrDatabaseSharePages,
        nrDatabaseCustomizePersonalViews = iml.DatabaseOperation.nrDatabaseCustomizePersonalViews,
        nrDatabaseCustomizePublicViews = iml.DatabaseOperation.nrDatabaseCustomizePublicViews,
        nrDatabaseCreateSystemPages = iml.DatabaseOperation.nrDatabaseCreateSystemPages,

        nrDatabaseAllowExternalUsersInDefaultDocumentCalculation =
            iml.DatabaseOperation.nrDatabaseAllowExternalUsersInDefaultDocumentCalculation,

        nrDatabaseAllowExternalUsersInDefaultFolderCalculation =
            iml.DatabaseOperation.nrDatabaseAllowExternalUsersInDefaultFolderCalculation
    }

    public enum NOSType
    {
        nrExternalNOS = iml.NOSType.nrExternalNOS,
        nrInternalNOS = iml.NOSType.nrInternalNOS,
        nrAllNOS = iml.NOSType.nrAllNOS
    }

    public enum EMOperation
    {
        OperationUnknown = iml.EMOperation.OperationUnknown,
        OperationCopy = iml.EMOperation.OperationCopy,
        OperationMove = iml.EMOperation.OperationMove,
        OperationMarkFiled = iml.EMOperation.OperationMarkFiled,
        OperationMarkFilingError = iml.EMOperation.OperationMarkFilingError
    }

    public enum EMFilingRequestType
    {
        FilingRequestUnknown = iml.EMFilingRequestType.FilingRequestUnknown,
        FilingRequestFile = iml.EMFilingRequestType.FilingRequestFile,
        FilingRequestFolder = iml.EMFilingRequestType.FilingRequestFolder
    }

    public enum EMClientType
    {
        ClientUnknown = iml.EMClientType.ClientUnknown,
        ClientBlackberry = iml.EMClientType.ClientBlackberry,
        ClientWindowsMobile = iml.EMClientType.ClientWindowsMobile,
        ClientMSOutlook = iml.EMClientType.ClientMSOutlook,
        ClientLotusNotes = iml.EMClientType.ClientLotusNotes,
        ClientGroupWise = iml.EMClientType.ClientGroupWise,
        ClientMobilityServer = iml.EMClientType.ClientMobilityServer,
        ClientWeb = iml.EMClientType.ClientWeb,
        ClientIPhone = iml.EMClientType.ClientIPhone,
        ClientCommunicationServer = iml.EMClientType.ClientCommunicationServer
    }

    public enum EMFolderMappingStatus
    {
        EMMappingUnknown = iml.EMFolderMappingStatus.EMMappingUnknown,
        EMMappingFailed = iml.EMFolderMappingStatus.EMMappingFailed,
        EMMappingSucceeded = iml.EMFolderMappingStatus.EMMappingSucceeded,
        EMMappingInitialized = iml.EMFolderMappingStatus.EMMappingInitialized
    }

    public enum EMRequestStatus
    {
        EMRequestUnknown = iml.EMRequestStatus.EMRequestUnknown,
        EMRequestServerCanceled = iml.EMRequestStatus.EMRequestServerCanceled,
        EMRequestExceededMaxRetries = iml.EMRequestStatus.EMRequestExceededMaxRetries,
        EMRequestErrorRetry = iml.EMRequestStatus.EMRequestErrorRetry,
        EMRequestFailure = iml.EMRequestStatus.EMRequestFailure,
        EMRequestDeleted = iml.EMRequestStatus.EMRequestDeleted,
        EMRequestDeleting = iml.EMRequestStatus.EMRequestDeleting,
        EMRequestComplete = iml.EMRequestStatus.EMRequestComplete,
        EMRequestProcessing = iml.EMRequestStatus.EMRequestProcessing,
        EMRequestSubmitted = iml.EMRequestStatus.EMRequestSubmitted
    }

    public enum StringSearchAnchor
    {
        nrAnchorStart = iml.StringSearchAnchor.nrAnchorStart,
        nrAnchorContains = iml.StringSearchAnchor.nrAnchorContains,
        nrAnchorEnd = iml.StringSearchAnchor.nrAnchorEnd
    }

    public enum SearchAttributeTypeModifier
    {
        nrSearchEnabledOrDisabled = iml.SearchAttributeTypeModifier.nrSearchEnabledOrDisabled,
        nrSearchEnabledOnly = iml.SearchAttributeTypeModifier.nrSearchEnabledOnly,
        nrSearchDisabledOnly = iml.SearchAttributeTypeModifier.nrSearchDisabledOnly
    }

    public enum ProfileErrorCode
    {
        nrErrorFieldRequired = iml.ProfileErrorCode.nrErrorFieldRequired,
        nrErrorFieldDisabled = iml.ProfileErrorCode.nrErrorFieldDisabled,
        nrErrorItemInvalid = iml.ProfileErrorCode.nrErrorItemInvalid,
        nrFieldErrorRelation = iml.ProfileErrorCode.nrFieldErrorRelation
    }

    public enum ACLType
    {
        nrGroup = iml.ACLType.nrGroup,
        nrUser = iml.ACLType.nrUser
    }

    public enum imSpecialFolderIDs
    {
        imRootFolderID = iml.imSpecialFolderIDs.imRootFolderID
    }
// ReSharper restore InconsistentNaming
}