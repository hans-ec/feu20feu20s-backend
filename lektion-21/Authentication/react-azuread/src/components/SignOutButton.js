import React from 'react'
import { useMsal } from '@azure/msal-react'

const SignOutButton = () => {
    const { instance } = useMsal()

    const handleSignOut = () => {
        instance.logoutPopup({ postLogoutRedirectUri: '/', mainWindowRedirectUri: '/' })
    }

    return (
        <button onClick={handleSignOut} className="btn btn-outline-secondary">Sign Out</button>
    )
}

export default SignOutButton
