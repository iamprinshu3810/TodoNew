
export const fetchData = async (url, userData) => {
    let token = localStorage.getItem('token');
    const data = await fetch(url, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token

        },
        body: JSON.stringify(userData)
    });

    return data.json();
}
export const fetchLoginData = async (url, userData) => {
    const data = await fetch(url, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',

        },
        body: JSON.stringify(userData)
    });

    return data.json();
}


