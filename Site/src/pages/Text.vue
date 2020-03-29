<template>
<div>
  Text
</div>
</template>

<script>
  export default {
    mounted() {
      let module = this;
      this.$nextTick(() => {
        console.log(module.qr)
        console.log(module.$parent.qr)
        console.log(module.test)
        console.log(module.$parent.test)
        //module.$parent.$emit('updateQR', 'http://qr-code-generator.info/')
      })

    }
  }
</script>
