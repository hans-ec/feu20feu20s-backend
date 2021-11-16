import React from 'react'
import { useMsal } from '@azure/msal-react'
import { loginRequest } from '../authConfig'

const SignInButton = () => {
    const { instance } = useMsal()

    const handleSignIn = () => {
        instance.loginPopup(loginRequest).catch(error => console.log(error))
    }

    return (
        <button onClick={handleSignIn} className="btn btn-outline-secondary">Sign In</button>
    )
}

export default SignInButton
