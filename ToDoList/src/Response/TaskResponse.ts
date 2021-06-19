import { Task } from "src/app/Models/Task";

export interface ApiResponse {
    data: Task[];
    success: boolean;
    message: string;
}