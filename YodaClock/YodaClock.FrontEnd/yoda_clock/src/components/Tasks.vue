<template>
<div id="tasks">
        <div v-bind:key="task.id" v-for="task in tasks" class="task"> 
        <input type="checkbox" v-on:change="markComplete" v-bind:checked="tasks.progress" id="checkbox">
        <br>
        {{task.about}}
        </div>
</div>
</template>

<script>
export default {
    name:"Tasks",
    data(){
        return{
                tasks:[
                {
                    about: "Stream earth with voice over commentary about earth being flat.",
                    progress: false
                },  
                {
                    about: "Figure out how to make a lightsaber.",
                    progress: false
                },
                {
                    about: "Learn Yoda grammar.",
                    progress: false
                },
                {
                    about: "Go out to space without helmet,",
                    progress: false
                }
            ]
        }
    },
    methods:{
        markComplete(){
            this.tasks.progress = !this.tasks.progress
        }

    }
}
</script>
<style scoped>
.task
{
    font-size: 18px;
    text-align: left;
    border-style: solid;
    border-color:rgba(23,162,184,0.1);
    background-color: rgba(23,162,184,0.1);
    margin: 2px;
    padding:10px;
}
#tasks{
    padding:10px;
    float:right;
    width:20%;
}

#checkbox{
    width:40px;
    height: 40px;
    color:black;
    margin:auto;
text-align: center;}

</style>