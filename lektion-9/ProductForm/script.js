fetch("https://localhost:44308/api/Categories").then(res => res.json()).then(data => {
    for(let option of data)
        document.getElementById("category").innerHTML += `<option value="${option.id}">${option.name}</option>`
})


document.getElementById("createProductForm").addEventListener("submit", function(e) {
    e.preventDefault()

    let json = JSON.stringify({
        name: e.target[0].value,
        shortDescription: e.target[1].value,
        longDescription: e.target[2].value,
        price: e.target[3].value,
        categoryId: e.target[4].value
    })

    fetch("https://localhost:44308/api/products", {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: json
    })
})