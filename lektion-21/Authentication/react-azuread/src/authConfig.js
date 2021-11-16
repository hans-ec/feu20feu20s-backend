export const msalConfig = {
    auth: {
        clientId: 'ENTER_YOUR_APPLICATON_CLIENT_ID_HERE',
        redirectUri: 'http://localhost:3000',
        authority: 'https://login.microsoftonline.com/ENTER_YOUR_TENANT_ID_HERE'
    },
    cache: {
        cacheLocation: 'sessionStorage',
        storeAuthStateInCookie: false
    }
}

export const loginRequest = {
    scopes: [
        'User.Read',
        'User.ReadWrite',
        'User.ReadWrite.All'
    ]
}

export const graphConfig = {
    me: 'https://graph.microsoft.com/v1.0/me/',
    myPhoto: 'https://graph.microsoft.com/v1.0/me/photo/$value'
}