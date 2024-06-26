//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.20.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming



export interface AccountModel {
    Id: string;
    UserName: string;
    Location: LocationModel;
}

export interface LocationModel {
    city: string;
    postcode: string;
    street: string;
    number: string;
    longitude: number;
    latitude: number;
}

export interface ItemChartSeries {
    name: Date;
    value: number;
}

export interface OpeningHoursModel {
    DayOfWeek: DayOfWeek;
    StartTime: string;
    EndTime: string;
}

export enum DayOfWeek {
    Sunday = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
}

export interface ItemPriceRequest {
    Price: number;
    ShopId: number;
}

export interface ItemRequest {
    Barcode: string;
    Name: string;
    Details: string;
    Quantity: number;
    Unit: string;
}

export interface LoginRequest {
    Email: string;
    Password: string;
}

export interface RefreshTokenRequest {
    RefreshToken: string;
}

export interface RegisterRequest {
    UserName: string;
    Password: string;
    Email: string;
}

export interface RegisterShopRequest {
    Company: string;
    Password: string;
    Email: string;
    Location: LocationModel;
}

export interface ShoppingListItemRequest {
    Count: number;
    ItemId: string;
    IsPriority: boolean;
}

export interface ShoppingListRequest {
    Name: string;
    Details: string;
}

export interface ShopRequest {
    Name: string;
    Details: string;
    CompanyName: string;
    Location: LocationModel;
    OpeningHours?: OpeningHoursModel[] | undefined;
}

export interface ItemChartResponse {
    name: string;
    series?: ItemChartSeries[] | undefined;
}

export interface ItemQueryResponse {
    price: number;
    createdAt: Date;
    itemBarcode: string;
    itemName: string;
    itemUnit: string;
    itemQuantity: number;
    shopName: string;
    shopId: string;
    distance: number;
}

export interface ItemResponse {
    barcode: string;
    name: string;
    details: string;
    quantity: number;
    unit: string;
    creator: Account;
}

export interface IdentityUserOfString {
    Id?: string | undefined;
    UserName?: string | undefined;
    NormalizedUserName?: string | undefined;
    Email?: string | undefined;
    NormalizedEmail?: string | undefined;
    EmailConfirmed: boolean;
    PasswordHash?: string | undefined;
    SecurityStamp?: string | undefined;
    ConcurrencyStamp?: string | undefined;
    PhoneNumber?: string | undefined;
    PhoneNumberConfirmed: boolean;
    TwoFactorEnabled: boolean;
    LockoutEnd?: Date | undefined;
    LockoutEnabled: boolean;
    AccessFailedCount: number;
}

export interface IdentityUser extends IdentityUserOfString {
}

export interface Account extends IdentityUser {
    Id: string;
    Location?: Location | undefined;
}

export interface Location {
    Id: number;
    City: string;
    Postcode: string;
    Street: string;
    Number: string;
    Longitude: number;
    Latitude: number;
}

export interface JwtAuthResult {
    AccessToken: string;
    RefreshToken: RefreshToken;
    Roles: string[];
}

export interface JwtAuthResponse extends JwtAuthResult {
}

export interface RefreshToken {
    UserName: string;
    TokenString: string;
    ExpireAt: Date;
}

export interface LoginResponse {
    UserName: string;
    Role: string;
    OriginalUserName: string;
    AccessToken: string;
    RefreshToken: string;
    Email: string;
}

export interface RegisterResponse {
    Message: string;
}

export interface ShoppingListItemResponse {
    id: number;
    itemId: string;
    count: number;
    itemName: string;
    isPriority: boolean;
}

export interface ShoppingListResponse {
    id: number;
    name: string;
    details: string;
    dateModified: Date;
    creator: AccountModel;
    shoppingListItems: ShoppingListItemResponse[];
}

export interface ShopResponse {
    id: number;
    name: string;
    details: string;
    location: LocationModel;
    creator: AccountModel;
    company: AccountModel;
    openingHours?: OpeningHoursModel[] | undefined;
    distanceFromUser: number;
}