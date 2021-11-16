import { AuthenticatedTemplate, UnauthenticatedTemplate } from '@azure/msal-react'
import React from 'react'
import ProfilePage from './ProfilePage'

const MainContent = () => {
    return (
        <div>
            <AuthenticatedTemplate>
                <ProfilePage />
            </AuthenticatedTemplate>

            <UnauthenticatedTemplate>
                <h5 className="card-title">Inte Inloggad</h5>
            </UnauthenticatedTemplate>
        </div>
    )
}

export default MainContent
