import axios from "axios";

export const addCustomer = async (details) => {
    const headers = { 
        
    };
  
    return axios.post(`https://0hbznkd9k0.execute-api.ap-south-1.amazonaws.com/dev/customer/`,
      details,
      { headers: headers, }
    ).then(function (res) {
      return res.data;
    }).catch(function (error) {
      if(error.request.readyState == 4 && error.request.response !== "" ){
          return error.response;
        } else {
          return { status: 999 };
        }
    });
  }

