export interface User {
  
  userName?: string;
  password?: string;
  role?: string;
  membershipId?: number;
  isLockedOut?: boolean;

}

export class login {
 
  userName?: string;
  password?: string;
   role?: string;
  membershipId?: number;
}
export interface MyResponse {
 
  membershipId: number;
  userName: string;
  role?: string;
}

export class Signup {

  membershipTypeCode: string | undefined;
  userName: string | undefined;
  aliasName: string | undefined;
  password: string | undefined;
  eMail: string | undefined;
  tandCAccepted: boolean | undefined;
  profileImage: File | undefined;
  imageContentType: string | undefined;
  isPrimary: boolean | undefined;
  salutation: string | undefined;
  firstName: string | undefined;
  middleName: string | undefined;
  lastName: string | undefined;
  dob: Date | undefined;
  sex: string | undefined;
  email: string | undefined;
  phoneAreaCode: string | undefined;
  phone: string | undefined;
  homePhone: string | undefined;
  mobilePhone: string | undefined;
  fax: string | undefined;
  preferredContact: string | undefined;
  addressTypeId: number | undefined;
  address1: string | undefined;
  address2: string | undefined;
  address3: string | undefined;
  countryId: number | undefined;
  regionId: number | undefined;
  cityId: number | undefined;
  postCode: string | undefined;
  status: boolean | undefined;
  active: boolean | undefined;




}
export class assets {
  assetno: number | undefined;
  staffs: number | undefined;
  owner: number | undefined;
  assetType: number | undefined;
  admin: number | undefined;
  vendor: number | undefined;
  //assetstaffs?: number;
}

export interface CountryList {

  countryCode: string | undefined; 
  countryId : number | undefined; 
 
  countryName: string| undefined; 

}

export interface region {
  regionId:  number| undefined; 
  regionCode: string| undefined;
  regionName: string| undefined; 
 

}
export interface addressType {
  typeId: number | undefined;
  typeCode: string | undefined;
  typeName: string | undefined;


}
export interface city {
  cityId: number |undefined;
  cityCode: string|undefined;
  cityName: string|undefined;
 

}
export interface role {

  roleCode: string | undefined;
  roleId: number | undefined;
  roleName: string | undefined;

}
export class Vendor {

  
  isPrimary: boolean | undefined;
  salutation:string | undefined;
  vendorName: string | undefined;
  firstName: string | undefined;
  middleName: string | undefined;
  lastName: string | undefined;
  dob: Date | undefined;
  sex: string | undefined;
  email: string | undefined;
  phoneAreaCode: string | undefined;
  phone: string | undefined;
  homePhone: string | undefined;
  mobilePhone: string | undefined;
  fax: string | undefined;
  preferredContact: string | undefined;
  webSite: string | undefined;
  addTypeId: number | undefined;
  address1: string | undefined;
  address2: string | undefined;
  address3: string | undefined;
  cityId: number | undefined;
  regionId: string | undefined;
  countryId: string | undefined;
  postCode: string | undefined;
  status: boolean | undefined;
  active: boolean | undefined;

}


export class UserItems {

  membershipId: number | undefined;
  userName: string | undefined;
  role: string | undefined;
  active: string | undefined;
  isLockedOut: boolean | undefined;
}

export class AssetSearchCriteria {
  searchNameOFUser?: string;
  searchAssetName?: string;
  searchAssetCode?: string;
}

