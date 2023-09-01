export class assetItems {

  assetId:number | undefined;
  name:string | undefined;
  code: string | undefined;
  description: string | undefined;
  status:boolean | undefined;
  assetTypeId: string | undefined;
  departmentId: string | undefined;
//assetStatusId:string | undefined;
  vendorId: string | undefined;
  ownerId: string | undefined;
  userId: string | undefined;
  serialNumber: string | undefined;
  make: string | undefined;
  model: string | undefined;
  processor:string | undefined;
  memory: string | undefined;
  storage:string | undefined;
  operatingSystem: string | undefined;
  ipaddress: string | undefined;
  insuranceDetails: string | undefined;
  licenceDetails:string | undefined;
  licenceExpiry: string | undefined;
  purchaseDate:string | undefined;
  invoiceNumber: string | undefined;
  amc:string | undefined;
  warranty:string | undefined;
  remarks: string | undefined;
  location: string | undefined;
//toolId: number | undefined;
  toolName: string | undefined;
  toolSerialNo: number | undefined;
  isInternal: boolean |undefined;
  keys: string | undefined
  toolStatus: boolean | undefined;
  active: boolean | undefined;
  assetType: string | undefined;
  department: string | undefined;
//assetStatusId:string | undefined;
  vendor: string | undefined;
  owner: string | undefined;
  user: string | undefined;

}

export class assetsdummy {

  assetId?:number;
  name?:string ;
  code?: string ;
  description?: string;
  status?: boolean;
  assetTypeId?: string; 
  departmentId?: string; 
  assetStatusId?:string; 
  vendorId?: string;
  ownerId?: string; 
  userId?: string; 
  serialNumber?: string; 
  make?: string;
  model?: string; 
  processor?:string; 
  memory?: string; 
  storage?:string; 
  operatingSystem?: string;
  ipaddress?: string; 
  insuranceDetails?: string; 
  licenceDetails?:string; 
  licenceExpiry?: string; 
  purchaseDate?:string; 
  invoiceNumber?: string; 
  amc?:string; 
  warranty?:string; 
  remarks?: string; 
  location?: string; 
  toolId?: number; 
  toolName?: string; 
  toolSerialNo?: number; 
  isInternal?: boolean;
  keys?: string;
  toolStatus?: boolean;
  active?: boolean;

  assetType?: string;
  department?: string;
 // assetStatus?: string;
  vendor?: string;
  owner?: string;
  user?: string; 

}

export interface AssetTableList {
  assetId?:number;
  name?:string ;
  code?: string ;
  description?: string;
  status?: boolean;
  assetTypeId?: string; 
  departmentId?: string; 
  assetStatusId?:string; 
  vendorId?: string;
  ownerId?: string; 
  userId?: string; 
  serialNumber?: string; 
  make?: string;
  model?: string; 
  processor?:string; 
  memory?: string; 
  storage?:string; 
  operatingSystem?: string;
  ipaddress?: string; 
  insuranceDetails?: string; 
  licenceDetails?:string; 
  licenceExpiry?: string; 
  purchaseDate?:string; 
  invoiceNumber?: string; 
  amc?:string; 
  warranty?:string; 
  remarks?: string; 
  location?: string;
  toolId?: number;
  toolName?: string;
  toolSerialNo?: number;
  isInternal?: boolean;
  keys?: string;
  toolStatus?: boolean;
  active?: boolean;

  assetType?: string;
  department?: string;
 // assetStatus?: string;
  vendor?: string;
  owner?: string;
  user?: string; 

}

export class Tools{

  name:string | undefined;
  isInternal: boolean | undefined;
  serialNumber: number | undefined;
  keys: string | undefined;
  assetId:number | undefined;
  toolId:number | undefined;
  status:boolean | undefined;
  active:boolean | undefined;
}
export class AssetIdList {

  assetId: number | undefined;
  assetName: string | undefined;

}




export class AssetStatus{
  
  code:string | undefined;
  description:string | undefined;
  status:boolean | undefined;
}

export class AssetTypeList {

  assetTypeId: number | undefined;
  assetTypeCode: string | undefined;
  assetTypeDescription: string | undefined;
}
export class DepartmentList {

  departmentId: number | undefined;
  departmentCode: string | undefined;
  departmentDescription: string | undefined;
}


export class VendorList {

  vendorId: number | undefined;
  vendorName: string | undefined;
 
}
export class OwnerList {

  ownerId: number | undefined;
  ownerName: string | undefined;

}
export class UserList {

  userId: number | undefined;
  userName: string | undefined;

}
export class Drop {

  assetTypeList!: AssetTypeList[];
  departmentList!: DepartmentList[];
  vendorlist!: VendorList[];
  ownerList!: OwnerList[];
  userList!: UserList[];
}
