import http from 'k6/http';
import { sleep,check } from 'k6';



export const options = {
    vus: 10,
    duration: '10s'
}

export default () => {
    const url = 'http://localhost:5234/api/products';
    const body = JSON.stringify({
        name : "myProduct",
        category:"wrong one"
    });

    const params = {
        headers: {
            'Content-Type':'application/json'
        }
    }
    const response = http.post(url, body, params);

    check(response,
        {
            'status 400':(x)=>x.status===400
        });
}

