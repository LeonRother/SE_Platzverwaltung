<template>
  <div class="mx-32">
    <h1 class="text-2xl my-4 font-bold text-center">Demo</h1>

    <table class="w-full bg-gray-100">
      <thead class="bg-gray-200">
        <tr>
          <th class="w-1/2">Building Label
            <select class="w-16 mx-4 font-normal" @change="updateTable()" v-model="selectedBuilding">
              <option value=""></option> <!-- TODO: when empty is selected again, v-model binds to undefined and request fails -->
              <option v-for="building in buildings" :key="building.id" :value="building">
                {{ building.label }}
              </option>
            </select>
          </th>
          <th class="w-1/2">BuildingID</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="floor in floors" :key="floor.id" class="text-center border border-gray-200">
          <td>{{ floor.label }}</td>
          <td>{{ floor.buildingID }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'SelectionView',
  data() {
    return {
      buildings: null,
      selectedBuilding: null,
      floors: null
    }
  },
  methods: {
    fetchBuildings() {
      axios.get('https://localhost:7000/building')
      .then(res => {
        this.buildings = res.data;
      })
      .catch(error => {
        document.getElementById('message').innerText = error;
        console.error('Error fetching building data:', error);
      });
    },
    updateTable() {
      axios.get("https://localhost:7000/floor/" + this.selectedBuilding.id)
      .then(res => {
        this.floors = res.data;
      });
    }
  },
  mounted() {
    this.fetchBuildings();
  }
}
</script>
