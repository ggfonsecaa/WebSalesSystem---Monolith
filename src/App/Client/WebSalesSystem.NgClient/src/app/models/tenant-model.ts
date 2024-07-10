export class TenantModel { 
    name?: string;
    email?: string;
    description?: string;
    storageType?: string;
    dbProvider?: string;
    storageName?: string;
    useSubTenants?: boolean;
    allowExternalRegister?: boolean;
    useEmailConfirmation?: boolean;
}