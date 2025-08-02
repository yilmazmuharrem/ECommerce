
import { Alert, AlertTitle, Button,  Container, List, ListItem, ListItemText } from "@mui/material";
import request from "../../api/requests";
import { useState } from "react";

export default function ErrorPage(){

  const [validationErrors, setValidationErrors] = useState<string[]>([])

  function getValidationError(){
request.Errors.getValidationError().then(()=> console.log("no validation")).catch(error=>setValidationErrors(error))
  }
    return(
    <>
    <Container>
      {
        validationErrors.length> 0  && (
          <Alert severity="error" sx={{mb:2}}>
            <AlertTitle> Validation Errors </AlertTitle>
            <List>
          {
            validationErrors.map((index)=> (
              <ListItem key={index}>
                <ListItemText></ListItemText>
              </ListItem>
            ))
          }
            </List>
          </Alert>
        )
      }
      <Button  sx={{mr:2}} variant="contained" onClick={()=> request.Errors.get400Error().catch(error=>console.log(error))}  > 400 Error</Button>
      <Button  sx={{mr:2}} variant="contained" onClick={()=> request.Errors.get401Error().catch(error=>console.log(error))}  > 401 Error</Button>
      <Button  sx={{mr:2}} variant="contained" onClick={()=> request.Errors.get404Error().catch(error=>console.log(error))}  > 404 Error</Button>
      <Button  sx={{mr:2}} variant="contained" onClick={()=> request.Errors.get500Error().catch(error=>console.log(error))}  > 500 Error</Button>
      <Button  sx={{mr:2}} variant="contained" onClick={getValidationError }  > server Error</Button>

    </Container>

    </>
    )
}