<template>
  <section class="section">
    <div class="container">
      <h2 class="title">Movies</h2>
      <!-- {{ this.$route.params.id}} -->
      <div v-if="movie!=null" class="content">
        <strong>Title:</strong>
        {{ movie.title }}
        <br>
        <strong>Description:</strong>
        {{ movie.description}}
        <br>
        <strong>Type:</strong>
        {{ movie.type }}
        <br>
        <strong>Director:</strong>
        {{ movie.director}}
        <br>
        <strong>Producer:</strong>
        {{ movie.producer}}
        <br>
        <strong>Date Time:</strong>
        {{ movie.dateTime}}
        <br>

        <!-- {{ JSON.stringify(movie)}} -->
      </div>
    </div>
  </section>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      movie: null
    };
  },
  mounted() {
    var _this = this;
    axios
      .get("http://localhost:5000/movies/" + this.$route.params.id)
      .then(function(res) {
        _this.movie = res.data;
        console.log("Data: ", res);
      })
      .catch(function(error) {
        console.log("Error:", error);
      })
      // axios.post('http://localhost:5000/movies',{
      //   title:"Harry",
      // 	description:"Leonsardoasdsada",
      // 	type:"Fantadassdadsy",
      // 	director:"lalaasadala",
      // 	producer:"adsadadsadasdaaaaaaaaaaaaaaaaaaaaaad",
      // 	datetime:"2018-09-12T12:42:31Z",
      // 	seating: 5,
      //   price : 5

      //   }
      // )
      .then(function(res) {
        console.log("Data: ", res);
      })
      .catch(function(error) {
        console.log("Error:", error);
      });
  }
};
</script>
