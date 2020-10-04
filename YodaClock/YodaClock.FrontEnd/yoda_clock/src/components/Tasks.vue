<template>
<div id="tasks">
        <div v-bind:key="task.id" v-for="task in tasks" class="task"> 
        <input type="checkbox" v-on:change="markComplete" v-bind:checked="tasks.progress" id="checkbox">
        {{task.about}}
        {{task.progress}}
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
                    about: "Figure out how to make a lightsaber.",
                    progress: true
                },
                {
                    about: "Figure out how to make a lightsaber.",
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
    font-size: 20px;
    text-align: left;
    border-style: solid;
    border-color:rgba(83,162,100,0.4);
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
}

</style>