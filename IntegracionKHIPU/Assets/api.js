window.api = {};

(() => {
    const req = (url, data, method, isFormData) => {
        if (method == 'GET') {
            if (data) {
                let queryString = '';
                for (const key in data) {
                    if (data.hasOwnProperty(key)) {
                        if (queryString.length === 0) {
                            queryString += '?';
                        } else {
                            queryString += '&';
                        }
                        queryString += encodeURIComponent(key) + '=' + encodeURIComponent(data[key]);
                    }
                }
                url += queryString;
            }
            return fetch(baseUrl + url, {
                method,
            }).then(res => res.json());
        } else {
            if (isFormData) {
                return fetch(baseUrl + url, {
                    method,
                    body: data,
                }).then(res => res.json());
            } else {
                return fetch(baseUrl + url, {
                    method,
                    headers: { 'Content-Type': 'application/json; charset=UTF-8' },
                    body: data ? JSON.stringify(data) : undefined,
                }).then(res => res.json());
            }
        }
    }

    const get = (url, data) => req(url, data, 'GET', false);
    const post = (url, data) => req(url, data, 'POST', false);
    const postFormData = (url, data) => req(url, data, 'POST', true);
    const deleteReq = (url, data) => req(url, data, 'DELETE', false);


    api.Pagos = {};
    api.Pagos.Get_Banks = (params) => get('Pagos/Get_Banks', params)
    api.Pagos.Create_Payment = (params) => post('Pagos/Create_Payment', params)
    api.Pagos.Get_Payment_By_ID = (params) => get('Pagos/Get_Payment_By_ID', params)
   

})();
