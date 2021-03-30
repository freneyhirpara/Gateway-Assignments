import axios from "axios";
export const getCustomerById = async (id) => {
    const headers = { 

     };
    
    return axios.get(`https://0hbznkd9k0.execute-api.ap-south-1.amazonaws.com/dev/customer/${id}`,
      { headers: headers, }
    ).then(function (res) {
        
      return res;
    }).catch(function (error) {
      if(error.request.readyState == 4 && error.request.response !== "" ){
          return error.response;
        } else {
          return { status: 999 };
        }
    });
  }