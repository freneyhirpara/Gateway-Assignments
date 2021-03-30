import React,{useState,useEffect} from 'react'
import { useParams } from 'react-router';
import {getCustomerById} from '../../api/getCustomerById';
import "./CustomerDetail.css";

function CustomerDetail() {
    const [dataById, setDataById] = useState("");
    let {id}= useParams()

    useEffect(() => {
        getById(id);
     }, [])

    async function getById(id){

        const res = await getCustomerById(id);
        console.log(res.data[0])
        setDataById(res.data[0]);
        console.log(dataById)
      }


    return (
        <div className="container">
            <div className="row">
                <div className="col-md-4 col-12 text-md-right text-center">
                    <img src={dataById.image} height="300" width="300" />
                </div>
                
                <div  className="border-left col-md-8 col-12 px-4">
                    <div class="row m-0">
                        <div className="col-2">
                        <p>Name:</p>
                        </div>
                        <div className="col-10">
                        <p>{dataById.name}</p>
                        </div>
                    </div>
                    <div class="row m-0">
                    <div className="col-2">
                        <p>Email:</p>
                        </div>
                        <div className="col-10">
                        <p>{dataById.email}</p>
                        </div>
                    </div>
                    <div class="row m-0">
                    <div className="col-2">
                        <p>Contact:</p>
                        </div>
                        <div className="col-10">
                        <p>{dataById.contactnumber}</p>
                        </div>
                    </div>
                    <div class="row m-0">
                    <div className="col-2">
                        <p>Status:</p>
                        </div>
                        <div className="col-10">
                        <p>{dataById.status ? 'Active' : 'Inactive'}</p>
                        </div>
                    </div>
                </div>
            
            </div>
            
        </div>
            
            
    )
}

export default CustomerDetail
