import { Button, ButtonGroup, Typography } from "@mui/material";
import { useDispatch } from "react-redux";
import { increment,decrement, incrementByAmount} from "./counterSlice";
import { useAppSelector } from "../../hooks/hooks";

export default function Counter(){
const count = useAppSelector((state)=>state.counter.value)
const dispatch = useDispatch()
    return(
        <>
        <Typography>{count}</Typography>
        <ButtonGroup>
            <Button onClick={()=>dispatch(increment())}>
            incerement
            </Button>
            <Button  onClick={()=>dispatch(decrement())}>    
        decrement
            </Button>
            <Button onClick={()=>dispatch(incrementByAmount(5))} > incerementByAmount</Button>
        </ButtonGroup>
        
        
        </>
    )
}