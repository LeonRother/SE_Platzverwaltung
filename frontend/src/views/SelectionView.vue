<template>
  <div class="mx-32">
    <h1 class="text-2xl my-4 font-bold text-center">Demo</h1>

    <table class="w-full border border-gray-300">
      <thead class="bg-gray-50">
        <tr>
          <th class="w-1/2">Building
            <select class="w-16 mx-4 font-normal" @change="updateTable()" v-model="selectedBuilding">
              <option value=""></option>
              <option v-for="building in buildings" :key="building.id" :value="building">
                {{ building.label }}
              </option>
            </select>
            <p>Floors</p>
          </th>
          <th class="w-1/2">BuildingID</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="floor in floors" :key="floor.id" class="text-center">
          <td class="border border-gray-300">{{ floor.label }}</td>
          <td class="border border-gray-300">{{ floor.buildingID }}</td>
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
      axios.get("https://localhost:7000/building/" + this.selectedBuilding.id + "/floors")
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
