export type Response<T> = {
    data: T,
    hasError: false,
} | {
    hasError:true,
    errorCode: number,
    errorMessage: string,
}

export interface ResponseError  {
    errorCode: number,
    errorMessage: string,
}

export const DEFAULT_ERROR: ResponseError = {
    errorCode:404,
    errorMessage: 'Page not found',
}

export const ENDPOINT_ERROR = 'Endpoint cannot be accesed';