<template>
  <section class="section">
    <div class="container">
      <h2 class="title"></h2>
      <!-- {{ this.$route.params.id}} -->
      <div v-if="movie!=null" class="content">
        <h2 class="title">{{ movie.title }}</h2>
        <br>
        <strong>Opis:</strong>
        {{ movie.description}}
        <br>
        <strong>Gatunek:</strong>
        {{ movie.type }}
        <br>
        <strong>Rezyser:</strong>
        {{ movie.director}}
        <br>
        <strong>Producent:</strong>
        {{ movie.producer}}
        <br>
        <strong>Data:</strong>
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
  }
};
</script>
