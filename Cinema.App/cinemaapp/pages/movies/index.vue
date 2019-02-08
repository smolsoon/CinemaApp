<template>
  <section class="section">
    <div class="container">
      <h2 class="title">Filmy</h2>

      <div class="content">
       <div v-for='movie in movies' :key="movie._id">

          <strong>Title:  </strong> {{ movie.title }}
          <strong>Type:  </strong> {{ movie.type }}
          <strong>Date Time:  </strong> {{ movie.dateTime}}
           <nuxt-link :to="{name:'movies-id',params: { id:movie._id }}" class="movie">Szczegoły</nuxt-link>
          <br><br>
       </div>

      </div>


    </div>
  </section>
</template>
<script>
 import axios from 'axios'
 export default {
  data() {
    return {
      movies: []
    }
  },
  mounted() {
    var _this = this;
    axios.get('http://localhost:5000/movies')
    .then (function(res){
      _this.movies = res.data
      console.log('Data: ', res);

    })
    .catch( function(error){
      console.log('Error:' ,error);
    })
  }
}
</script>


