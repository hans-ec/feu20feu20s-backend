import React from 'react'

const ProfileData = ({graphData, photo}) => {
    console.log(photo)

    return (
        <div className="card text-center ">
            <img src={photo} className="card-img-top" alt="..." />
            <div className="card-body ">
                <h5 className="card-title">{graphData.displayName}</h5>
                <p className="card-text">
                    <p>{graphData.jobTitle}</p>
                </p>
            </div>
        </div>
    )
}

export default ProfileData
