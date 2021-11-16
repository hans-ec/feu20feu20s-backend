import React, {useState, useEffect} from 'react'
import { useMsal } from '@azure/msal-react'
import { loginRequest } from '../authConfig'

import ProfileData from '../components/ProfileData'
import { getGraphMe, getGraphMyPhoto } from '../graphAPI'

const ProfilePage = () => {
    const {instance, accounts} = useMsal()
    const [graphData, setGraphData] = useState(null)
    const [photo, setPhoto] = useState(null)

    function getProfileData() {
        instance.acquireTokenSilent({ ...loginRequest, account: accounts[0] })
        .then(res => getGraphMe(res.accessToken).then(data => setGraphData(data)))

        instance.acquireTokenSilent({ ...loginRequest, account: accounts[0] })
        .then(res => getGraphMyPhoto(res.accessToken).then(data => setPhoto(data)))
        
    }

    useEffect(() => {
        getProfileData()
    },[])


    return (
        <div>
            <div className="row">
                <div className="col-9"></div>
                <div className="col-3">
                    { graphData ? <ProfileData graphData={graphData} photo={photo} /> : <p></p>  }   
                </div>
            </div>
        </div>
    )
}

export default ProfilePage
