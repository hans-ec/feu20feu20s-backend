import { graphConfig } from "./authConfig";

export async function getGraphMe(accessToken) {
    return fetch(graphConfig.me, {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${accessToken}` 
        }
    }).then(res => res.json()).catch(error => console.log(error))
}

export async function getGraphMyPhoto(accessToken) {
    return fetch(graphConfig.myPhoto, {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${accessToken}` 
        }
    })
    .then(res => res.blob())
    .then(imageBlob => URL.createObjectURL(imageBlob))
    .catch(error => console.log(error))
}