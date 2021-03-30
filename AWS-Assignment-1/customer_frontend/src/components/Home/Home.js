import React,{useEffect,useState} from 'react';
import {getAllCustomers} from '../../api/getAllCustomers';

import "./Home.css";



function Home({history}) {

    const [data,setData] = useState("");
    
    useEffect(() => {
     
       
       getData().then(() => {
        document.getElementById('loader').classList.add('invisible');
      });
    }, [])
    
    


    async function getData(){
        const res = await getAllCustomers();
        
        setData( res.map((r,index)=>{
          
            return (
              
            <tr key={index}>
              <td  scope="row">{index+1}</td>
              <td scope="row"><img src={r.thumbnail} height="80px" width="80px" /></td>
              <td>{r.name}</td>
              <td>{r.email}</td>
              <td>{r.contactnumber}</td>
              <td>{r.status? 'Active' : 'Inactive'}</td>
              <td><i onClick={()=>history.push("/"+r.id)} class="far fa fa-x fa-info-circle" ></i></td>
              
            </tr>
            )
          }))
    }

    return (
        <div class="content">
          <div id="loader" className="loader">
                Loading ...
              </div>
            <table id="myTable" className="table table-responsive table-hover m-auto pt-4" >
                <thead class="thead">
                  <tr>
                    <th scope="col">#</th>
                    <th scope="col">Image</th>
                    <th scope="col">Name</th>
                    <th scope="col">Email</th>
                    <th scope="col">Contact Number</th>
                    <th scope="col">Status</th>
                    <th scope="col">Actions</th>
                    
                  </tr>
                </thead>

                <tbody>{data}</tbody>
              </table>

              
                
        </div>
    )
}

export default Home
