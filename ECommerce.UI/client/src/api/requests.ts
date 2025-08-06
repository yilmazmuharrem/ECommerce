import  axios, { Axios, AxiosError, AxiosResponse }  from "axios";
import { toast } from "react-toastify";
import { router } from "../router/Router";

axios.defaults.baseURL="http://localhost:7139/api/"
axios.defaults.withCredentials = true;
axios.interceptors.response.use(response=>{

    return response
}, (error:AxiosError)=>{
    const {data,status} = error.response as AxiosResponse
        console.log("🚀 ~ data:", data)
    console.log("🚀 ~ status:", status)
    switch(status)
    {
        case 400:
            if (data.errors){
                const modelErrors : string[] =[];

                for (const key in data.errors){
                    modelErrors.push(data.errors[key])
                }
                throw modelErrors
            }
                        toast.error(data.title)

            break
         case 401:
            toast.error(data.title)
            break
        case 404:
           router.navigate("/not-found")
            break    
         case 500:
            router.navigate("/server-error",{state:{error:data,status:status}});
            break
            
          default:
            toast.error(data.title)
            break    
    }
    
    return Promise.reject(error.response)
})
const queries ={
    get:(url:string) => axios.get(url).then((response:AxiosResponse)=> response.data),
    post:(url:string,body:{}) => axios.post(url,body).then((response:AxiosResponse)=> response.data),
    put:(url:string,body:{}) => axios.put(url,body).then((response:AxiosResponse)=> response.data),
    delete:(url:string) => axios.delete(url).then((response:AxiosResponse)=> response.data),
}

const Errors = {
    get400Error:() => queries.get("/error/bad-request"),
    get401Error:() => queries.get("/error/unauthorized"),
    get404Error:() => queries.get("/error/not-found"),
    get500Error:() => queries.get("/error/server-error"),
    getValidationError:() => queries.get("/error/validation-error"),
}

const Catalog ={
    list:()=> queries.get("products"),
    details:(id:number) =>queries.get(`products/${id}`)
}

const Card ={
    get:()=> queries.get("card"),
    addItem:(productId:number,quantity=1) =>queries.post(`card?productId=${productId}&quantity=${quantity}`,{}),
    deleteItem:(productId:number,quantity=1)=>queries.delete(`card?productId=${productId}&quantity=${quantity}`)
}


const Account = {
    login: (formdata:any) => queries.post("account/login",formdata),
    register :(formdata:any) => queries.post("account/register",formdata),
}


const request  ={
    Catalog,Errors,Card,Account
}

export default request