import React,{useState} from 'react';
import {addCustomer} from '../../api/addCustomer';
import axios from "axios";
import './AddCustomer.css';

function AddCustomer({history}) {

    const [name, setName] = useState();
    const [email, setEmail] = useState();
    const [phoneNumber, setPhoneNumber] = useState();
    const [password, setPassword] = useState();
    const [image, setImage] = useState();


    const handleSubmit = async (e) => {
        const fd = new FormData();
        fd.append("name",name);
        fd.append("file",image);
        fd.append("password",password);
        fd.append("contactnumber",phoneNumber);
        fd.append("email",email);

        axios.post("https://0hbznkd9k0.execute-api.ap-south-1.amazonaws.com/dev/customer",fd).then(res=>history.push("/")).catch(err=>console.log(err))
         e.preventDefault();

         
        
    }

    return (
      
           <form className=" g-3 mt-3 w-75 m-auto" onSubmit={handleSubmit}>
             <h2 className="mb-5 mt-4 text-center"> Add Customer</h2>
             <div class="row">
        <div className="col-lg-6 col-md-6 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Name" className="form-label">
            Name
          </label>
          <input
            type="text"
            className="form-control"
            id="Name"
            required
            onChange={(e) => setName(e.target.value)}
          />
        </div>

        

        <div className="col-md-6 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Email" className="form-label">
            Email
          </label>
          <input
            type="email"
            className="form-control"
            id="Email"
            required
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="col-md-6 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Password" className="form-label">
            Password
          </label>
          <input
            type="password"
            className="form-control"
            id="Password"
            required
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <div className="col-md-6 px-lg-5 px-md-3 mt-3">
          <label htmlFor="PhoneNumber" className="form-label">
            Phone Number
          </label>
          <input
            type="text"
            className="form-control"
            id="PhoneNumber"
            required
            onChange={(e) => setPhoneNumber(e.target.value)}
          />
        </div>
        <div className="col-md-6 px-lg-5 px-md-3 mt-3">
          <label htmlFor="Image" className="form-label">
            Image
          </label>
          <input
            type="file"
            className="form-control"
            id="Image"
            required
            onChange={(e) => setImage(e.target.files[0])}
          />
        </div>

        
        </div>
        <center>
        <div className="mt-4">
          <button type="submit" className="add btn form-buttons">
            Add
          </button>
        </div>
        </center>
      </form>
       
    )
}

export default AddCustomer

