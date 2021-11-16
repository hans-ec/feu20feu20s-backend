import React from 'react'
import { useIsAuthenticated } from '@azure/msal-react'

import SignInButton from '../components/SignInButton'
import SignOutButton from '../components/SignOutButton'
import { NavLink } from 'react-router-dom'


const MainLayout = (props) => {
    const isAuthenticated = useIsAuthenticated()

    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-light bg-light shadow">
                <div className="container">
                    <NavLink className="navbar-brand" to="">React AzureAD</NavLink>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarText">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">

                        </ul>
                        <span className="navbar-text">
                           { isAuthenticated ? <SignOutButton /> : <SignInButton /> }
                        </span>
                    </div>
                </div>
            </nav>
            <div className="container mt-5">
                { props.children }
            </div>
        </>
    )
}

export default MainLayout
